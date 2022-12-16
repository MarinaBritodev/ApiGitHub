using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Take.Api.GitHub.Facades.Interfaces;
using Take.Api.GitHub.Models;
using Take.Api.GitHub.Models.Exceptions;
using Take.Api.GitHub.Models.GitHub;
using Take.Api.GitHub.Services.Intefaces;

namespace Take.Api.GitHub.Facades.GitHub
{
    public class GitHubFacade : IGitHubFacade
    {
        private readonly IGitHubService _gitHubService;

        public GitHubFacade(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public async Task<List<Repository>> GetOldestFiveRepositoriesDotNetAsync(string userGitHub)
        {
            var repositories = await _gitHubService.GetRepositoriesAsync(userGitHub);

            var oldestFiveRepositoriesDotNet = repositories.Where(r => !string.IsNullOrEmpty(r.Language) && r.Language.Equals(Constants.TYPE_LANGUAGE_REPOSITORY))
                                     .OrderBy(r => r.CreatedAt)
                                     .Take(Constants.REPOSITORIES_AMOUNT)
                                     .ToList();

            if (oldestFiveRepositoriesDotNet.Count == default)
            {
                var messageError = $"{Constants.MESSAGE_ERROR_REPOSITORIES_COUNT} - {userGitHub}";
                throw new RepositoryException(messageError, HttpStatusCode.NotFound);
            }

            return oldestFiveRepositoriesDotNet;
        }
    }
}
