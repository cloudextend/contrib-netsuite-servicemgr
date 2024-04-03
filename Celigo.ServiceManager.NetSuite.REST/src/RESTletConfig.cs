namespace Celigo.ServiceManager.NetSuite.REST
{
    public class RestletConfig
    {
        public string Script { get; set; }

        public string Deploy { get; set; }

        public string RestletName { get; set; }
        public int HttpTimeoutInMinutes { get; set; } = 2;

        public const string ConfigurationSectionName = "Celigo:NetSuite:REST";
    }

    public class RestletConfigOptions
    {
        public RestletConfig[] Restlets { get; set; }
    }
}