using System.Collections.Generic;
using System.Threading.Tasks;

using Serilog;

using Take.Api.GitHub.Models.GitHub;
using Take.Api.GitHub.Services.Intefaces;
using Take.Api.GitHub.Services.RestEase;

namespace Take.Api.GitHub.Services.GitHub
{
    public class GitHubService : IGitHubService
    {
        private readonly ILogger _logger;
        private readonly IGitHubRestEase _gitHubRestEase;


        public GitHubService(ILogger logger, IGitHubRestEase gitHubRestEase)
        {
            _logger = logger;
            _gitHubRestEase = gitHubRestEase;
        }

        public async Task<List<Repository>> GetRepositoriesAsync(string user)
        {
            _logger.Debug("Get Repositories On GitHub: {userGitHub}", user);

            var result = await _gitHubRestEase.GetRepositoriesAsync(user);

            return result;
        }
    }
}
