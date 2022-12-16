using System.Collections.Generic;
using System.Threading.Tasks;

using Moq;

using Shouldly;

using Take.Api.GitHub.Facades.GitHub;
using Take.Api.GitHub.Models.Exceptions;
using Take.Api.GitHub.Models.GitHub;
using Take.Api.GitHub.Services.Intefaces;
using Take.Api.GitHub.Tests.TestData;
using Take.Api.GitHub.Tests.TestData.GitHub;

using Xunit;

namespace Take.Api.GitHub.Tests.Facades
{
    public class GitHubFacadeTest
    {
        private readonly Mock<IGitHubService> _gitHubService;
        private readonly GitHubFacade _gitHubFacade;

        public GitHubFacadeTest()
        {
            _gitHubService = new Mock<IGitHubService>();
            _gitHubFacade = new GitHubFacade(_gitHubService.Object);
        }

        /// <summary>
        /// Test of GetOldestFiveRepositoriesDotNetAsync return List Repository
        /// </summary>
        [Theory]
        [InlineData(Constants.USERNAME_REPOSITORY)]
        public async Task GitHubFacade_ReturnRepositoriesAsync(string userGitHub)
        {
            var repositories = RepositoryTestData.GetRepositories();

            _gitHubService.Setup(r => r.GetRepositoriesAsync(userGitHub)).ReturnsAsync(repositories);

            var result = await _gitHubFacade.GetOldestFiveRepositoriesDotNetAsync(userGitHub);

            result.ShouldBeOfType<List<Repository>>();
        }

        /// <summary>
        /// Test of GetOldestFiveRepositoriesDotNetAsync return Repository Exception
        /// </summary>
        [Theory]
        [InlineData(Constants.USERNAME_REPOSITORY)]
        public async Task GitHubFacade_RepositoryExceptionAsync(string userGitHub)
        {
            var messageError = $"{Constants.MESSAGE_ERROR_REPOSITORIES_COUNT} - {userGitHub}";

            _gitHubService.Setup(s => s.GetRepositoriesAsync(userGitHub)).ReturnsAsync(RepositoryTestData.GetEmptyRepositories());

            var exception = await Should.ThrowAsync<RepositoryException>(() => _gitHubFacade.GetOldestFiveRepositoriesDotNetAsync(userGitHub));

            exception.ShouldBeOfType<RepositoryException>();

            exception.Message.ShouldBe(messageError);
        }
    }
}

