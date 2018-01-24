using SuiteTalk;
using System;
using System.Collections.Generic;
using System.Text;

namespace Celigo.ServiceManager.NetSuite
{
    public interface IPassportProvider
    {
        Passport GetPassport();
        //string GetDataCenter();
    }
}
