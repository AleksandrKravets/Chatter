namespace Chatter.API
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Chats
        {
            public const string GetAll = Base + "/chats";

            public const string Update = Base + "/chats/{chatId}";

            public const string Delete = Base + "/chats/{chatId}";

            public const string Get = Base + "/chats/{chatId}";

            public const string Create = Base + "/chats";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

            public const string Refresh = Base + "/identity/refresh";
        }
    }
}
