using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Take.Api.GitHub.Facades.Interfaces;
using Take.Api.GitHub.Models.GitHub;

namespace Take.Api.GitHub.Controllers
{
    /// <summary>
    /// controller that makes GitHub api call
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubFacade _gitHubFacade;

        /// <summary>
        /// construct to do dependecy injection
        /// </summary>
        /// <param name="gitHubFacade"></param>
        public GitHubController(IGitHubFacade gitHubFacade)
        {
            _gitHubFacade = gitHubFacade;
        }

        /// <summary>
        /// Get the 5 oldest C# repositories from Take on GitHub
        /// </summary>
        /// <param name="userGitHub">GitHub repository username</param>
        [HttpGet("{userGitHub}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Repository>>> GetRepositoriesAsync([FromRoute] string userGitHub)
        {
            var oldestRepositorieDotNet = await _gitHubFacade.GetOldestFiveRepositoriesDotNetAsync(userGitHub);
            return Ok(oldestRepositorieDotNet);
        }
    }
}
