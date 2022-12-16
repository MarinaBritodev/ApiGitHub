using System.Collections.Generic;
using System.Threading.Tasks;

using RestEase;

using Take.Api.GitHub.Models;
using Take.Api.GitHub.Models.GitHub;

namespace Take.Api.GitHub.Services.RestEase
{
    [Header("User-Agent", Constants.GITHUB_USER_AGENT)]
    public interface IGitHubRestEase
    {

        /// <summary>
        /// Get user Repositories on GitHub API
        /// </summary>
        /// <param name="repositoryName">Take repository username on GitHub</param>
        /// <returns>List de repositories from GitHub</returns>
        [Get("/users/{repositoryName}/repos")]
        Task<List<Repository>> GetRepositoriesAsync([Path("repositoryName")] string repositoryName);

    }
}
