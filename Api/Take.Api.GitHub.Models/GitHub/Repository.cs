using System;

using Newtonsoft.Json;

namespace Take.Api.GitHub.Models.GitHub
{
    public class Repository
    {
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

    }
}
