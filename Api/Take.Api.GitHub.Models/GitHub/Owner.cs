using Newtonsoft.Json;

namespace Take.Api.GitHub.Models.GitHub
{
    public class Owner
    {
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
