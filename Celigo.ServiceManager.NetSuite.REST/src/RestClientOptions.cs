namespace Celigo.ServiceManager.NetSuite.REST
{
    public class RestClientOptions
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }

        public const string ConfigurationSectionName = "Celigo:NetSuite:REST";
    }
}
