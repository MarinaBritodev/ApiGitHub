using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using RestEase;

using Serilog;
using Serilog.Exceptions;

using Take.Api.GitHub.Facades.GitHub;
using Take.Api.GitHub.Facades.Interfaces;
using Take.Api.GitHub.Facades.Strategies.ExceptionHandlingStrategies;
using Take.Api.GitHub.Models;
using Take.Api.GitHub.Models.Exceptions;
using Take.Api.GitHub.Models.UI;
using Take.Api.GitHub.Services.GitHub;
using Take.Api.GitHub.Services.Intefaces;
using Take.Api.GitHub.Services.RestEase;

namespace Take.Api.GitHub.Facades.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        private const string APPLICATION_KEY = "Application";
        private const string SETTINGS_SECTION = "Settings";

        /// <summary>
        /// Registers project's specific services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSingletons(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection(SETTINGS_SECTION).Get<ApiSettings>();

            // Dependency injection
            services.AddSingleton(settings)
                    .AddSingleton(settings.BlipBotSettings);

            AddFacades(services);
            AddService(services, settings);

            services.AddSingleton(provider =>
            {
                var logger = provider.GetService<ILogger>();
                return new Dictionary<Type, ExceptionHandlingStrategy>
                {
                    { typeof(ApiException), new ApiExceptionHandlingStrategy(logger) },
                    { typeof(NotImplementedException), new NotImplementedExceptionHandlingStrategy(logger) },
                    { typeof(RepositoryException), new RepositoryExceptionHandlingStrategy(logger)}
                };
            });

            // SERILOG settings
            services.AddSingleton<ILogger>(new LoggerConfiguration()
                     .ReadFrom.Configuration(configuration)
                     .Enrich.WithMachineName()
                     .Enrich.WithProperty(APPLICATION_KEY, Constants.PROJECT_NAME)
                     .Enrich.WithExceptionDetails()
                     .CreateLogger());
        }

        private static void AddService(IServiceCollection services, ApiSettings apiSettings)
        {
            services
                .AddSingleton(RestClient.For<IGitHubRestEase>(apiSettings.ApiGitHubSetting.Url))
                .AddSingleton<IGitHubService, GitHubService>();
        }

        private static void AddFacades(IServiceCollection services)
        {
            services
                .AddSingleton<IGitHubFacade, GitHubFacade>();
        }
    }
}
