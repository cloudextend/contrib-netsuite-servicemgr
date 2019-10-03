namespace Celigo.ServiceManager.NetSuite
{
    public interface IDataCenterConfiguration
    {
        string DataCenterDomain { get; }
    }

    public interface IConfigurationProvider
    {
        IDataCenterConfiguration DataCenter { get; }
    }

    public enum EndPointType { Beta = 2, Sandbox = 1, Production = 0}

    public class DataCenterConfiguration : IDataCenterConfiguration
    {
        public string DataCenterDomain { get; private set; }

        public DataCenterConfiguration(string dataCenterDomain)
        {
            this.DataCenterDomain = dataCenterDomain;
        }

        public DataCenterConfiguration(EndPointType type)
        {
            switch (type)
            {
                case EndPointType.Beta:
                    this.DataCenterDomain = "http://webservices.beta.netsuite.com";
                    break;
                case EndPointType.Sandbox:
                    this.DataCenterDomain = "http://webservices.sandbox.netsuite.com";
                    break;
                default:
                    this.DataCenterDomain = "http://webservices.netsuite.com";
                    break;
            }
        }
    }

    public class ConfigurationProvider : IConfigurationProvider
    {
        public IDataCenterConfiguration DataCenter { get; set; }

        public ConfigurationProvider()
        {
        }
    }
}
