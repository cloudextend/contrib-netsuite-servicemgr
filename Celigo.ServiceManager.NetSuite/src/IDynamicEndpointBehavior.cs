using System;
using System.ServiceModel.Description;

namespace Celigo.ServiceManager.NetSuite
{
    public interface IDynamicEndpointBehavior: IEndpointBehavior
    {
        bool IsEnabled();
    }
}
