using System;
using System.Collections.Generic;
using System.Linq;

using AutoFixture;

using Take.Api.GitHub.Models.GitHub;

namespace Take.Api.GitHub.Tests.TestData.GitHub
{
    public static class RepositoryTestData
    {

        public static List<Repository> GetEmptyRepositories()
        {
            return new List<Repository>();
        }

        public static List<Repository> GetRepositories()
        {
            var fixture = new Fixture();

            var repositories = fixture.Build<Repository>()
                                      .With(r => r.Language, "C#")
                                      .CreateMany(new Random().Next(5, 10)).ToList();

            return repositories;
        }

        public static List<Repository> GetOldestFiveRepositoriesDotnet(List<Repository> repositories)
        {
            var fiveRepositoriesDotnet = repositories.Where(r => !string.IsNullOrEmpty(r.Language) && r.Language.Equals(Constants.TYPE_LANGUAGE_REPOSITORY))
                                           .OrderBy(r => r.CreatedAt)
                                           .Take(5).ToList();

            return fiveRepositoriesDotnet;
        }
    }
}
