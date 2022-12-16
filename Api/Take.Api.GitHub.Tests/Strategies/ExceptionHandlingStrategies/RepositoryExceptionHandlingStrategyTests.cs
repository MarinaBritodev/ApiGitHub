using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using NSubstitute;

using Serilog;

using Shouldly;

using Take.Api.GitHub.Facades.Strategies.ExceptionHandlingStrategies;
using Take.Api.GitHub.Tests.Setup.Controller;

using Xunit;

namespace Take.Api.GitHub.Tests.Strategies.ExceptionHandlingStrategies
{
    public class RepositoryExceptionHandlingStrategyTests
    {

        private readonly ILogger _logger;

        public RepositoryExceptionHandlingStrategyTests()
        {
            _logger = Substitute.For<ILogger>();
        }

        private RepositoryExceptionHandlingStrategy CreateRepositoryExceptionHandlingStrategy()
        {
            return new RepositoryExceptionHandlingStrategy(_logger);
        }

        [Fact]
        public async Task HandleAsyncExpectedBehaviorAsync()
        {
            var repositoryExceptionHandlingStrategy = CreateRepositoryExceptionHandlingStrategy();

            var context = ControllerSetup.HttpContext;
            var exception = ControllerSetup.RepositoryException;

            var result = await repositoryExceptionHandlingStrategy.HandleAsync(
                context,
                exception);

            result.Response.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
        }
    }
}
