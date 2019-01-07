using System;
using System.ServiceModel.Description;

namespace Celigo.ServiceManager.NetSuite
{
    public interface IDynamicEndpointBehaviour: IEndpointBehavior
    {
        bool IsEnabled();
    }
}
