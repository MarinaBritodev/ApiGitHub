using System.Collections.Generic;
using System.Threading.Tasks;

using Take.Api.GitHub.Models.GitHub;

namespace Take.Api.GitHub.Facades.Interfaces
{
    public interface IGitHubFacade
    {
        /// <summary>
        /// Get the first 5 C# repositories by date
        /// </summary> 
        /// <param name="userGitHub"></param>
        /// <returns>List Repositories</returns>
        Task<List<Repository>> GetOldestFiveRepositoriesDotNetAsync(string userGitHub);
    }
}
