using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Shouldly;

using Take.Api.GitHub.Controllers;
using Take.Api.GitHub.Facades.Interfaces;
using Take.Api.GitHub.Tests.TestData;
using Take.Api.GitHub.Tests.TestData.GitHub;

using Xunit;

namespace Take.Api.GitHub.Tests.Controllers
{
    public class GitHubControllerTest
    {
        private readonly Mock<IGitHubFacade> _gitHubFacade;
        private readonly GitHubController _gitHubController;

        public GitHubControllerTest()
        {
            _gitHubFacade = new Mock<IGitHubFacade>();
            _gitHubController = new GitHubController(_gitHubFacade.Object);
        }

        /// <summary>
        /// Test of GetRepositoriesAsync method with ok return
        /// </summary>
        [Theory]
        [InlineData(Constants.USERNAME_REPOSITORY)]
        public async Task GitHubController_GetRepositoriesAsync_ReturnOkAsync(string userGitHub)
        {
            //arrenge
            var repositories = RepositoryTestData.GetRepositories();
            var oldestFiveRepositoriesDotNet = RepositoryTestData.GetOldestFiveRepositoriesDotnet(repositories);

            _gitHubFacade.Setup(c => c.GetOldestFiveRepositoriesDotNetAsync(userGitHub)).Returns(Task.FromResult(oldestFiveRepositoriesDotNet));

            // act
            var response = await _gitHubController.GetRepositoriesAsync(userGitHub);

            // assert
            response.Result.ShouldBeOfType<OkObjectResult>();
        }
    }
}
