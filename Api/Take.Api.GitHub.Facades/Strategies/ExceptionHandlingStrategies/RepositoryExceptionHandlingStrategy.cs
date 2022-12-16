using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Serilog;

using Take.Api.GitHub.Models;
using Take.Api.GitHub.Models.Exceptions;

namespace Take.Api.GitHub.Facades.Strategies.ExceptionHandlingStrategies
{
    public class RepositoryExceptionHandlingStrategy : ExceptionHandlingStrategy
    {
        private readonly ILogger _logger;

        public RepositoryExceptionHandlingStrategy(ILogger logger)
        {
            _logger = logger;
        }

        public override async Task<HttpContext> HandleAsync(HttpContext context, Exception exception)
        {
            var repositoryException = exception as RepositoryException;
            _logger.Error(repositoryException, "[{@user}] Error: {@exception}", context.Request.Headers[Constants.BLIP_BOT_HEADER], repositoryException.Message);

            context.Response.StatusCode = StatusCodes.Status404NotFound;

            return await Task.FromResult(context);
        }
    }
}
