using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    [Obsolete]
    public interface ITokenService
    {
        Task<RequestTokenResponse> GetRequestToken(string account, string callbackUrl);

        Task<AccessTokenResponse> GetAccessToken(string account, string requestToken, string tokenSecret, string verifier);
    }
}
