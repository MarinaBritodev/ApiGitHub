using System.Collections.Generic;
using System.Threading.Tasks;

using Moq;

using Serilog;

using Take.Api.GitHub.Models.GitHub;
using Take.Api.GitHub.Services.GitHub;
using Take.Api.GitHub.Services.RestEase;
using Take.Api.GitHub.Tests.TestData;
using Take.Api.GitHub.Tests.TestData.GitHub;

using Xunit;

namespace Take.Api.GitHub.Tests.Services
{
    public class GitHubServiceTest
    {
        private readonly Mock<ILogger> _logger;
        private readonly Mock<IGitHubRestEase> _gitHubRestEase;
        private readonly GitHubService _gitHubService;

        public GitHubServiceTest()
        {
            _logger = new Mock<ILogger>();
            _gitHubRestEase = new Mock<IGitHubRestEase>();
            _gitHubService = new GitHubService(_logger.Object, _gitHubRestEase.Object);
        }

        /// <summary>
        /// Test of GetRepositoriesAsync return List Repository
        /// </summary>
        [Theory]
        [InlineData(Constants.USERNAME_REPOSITORY)]
        public async Task GetRepositoriesAsync_NotThrowingExceptionAsync(string userGitHub)
        {
            // Arrange
            var repositories = RepositoryTestData.GetRepositories();
            _gitHubRestEase.Setup(r => r.GetRepositoriesAsync(userGitHub)).ReturnsAsync(repositories);

            // Act
            var result = await _gitHubService.GetRepositoriesAsync(userGitHub);

            // Assert
            Assert.IsType<List<Repository>>(result);
        }
    }
}
