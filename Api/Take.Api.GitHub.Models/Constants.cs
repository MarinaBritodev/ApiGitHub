namespace Take.Api.GitHub.Models
{
    public static class Constants
    {
        public const string BLIP_USER_HEADER = "X-Blip-User";
        public const string BLIP_BOT_HEADER = "X-Blip-Bot";
        public const string BLIP_BOT_KEY = "X-Bot-Key";
        public const string XML_EXTENSION = ".xml";
        public const string PROJECT_NAME = "Take.Api.GitHub";

        public const string TYPE_LANGUAGE_REPOSITORY = "C#";
        public const string GITHUB_USER_AGENT = "takenet";
        public const int REPOSITORIES_AMOUNT = 5;

        public const string MESSAGE_ERROR_REPOSITORIES_COUNT = "Not found C# repositories";
        public const string MESSAGE_ERROR_GITHUB_API = "Request Error GitHub Api";
    }
}
