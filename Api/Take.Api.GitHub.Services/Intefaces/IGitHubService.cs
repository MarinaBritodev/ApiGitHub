using System.Collections.Generic;
using System.Threading.Tasks;

using Take.Api.GitHub.Models.GitHub;

namespace Take.Api.GitHub.Services.Intefaces
{
    public interface IGitHubService
    {
        /// <summary>
        /// Get user repositories
        /// </summary>
        /// <param name="user">repository username</param>
        /// <returns>List Repository</returns>
        Task<List<Repository>> GetRepositoriesAsync(string user);
    }
}
