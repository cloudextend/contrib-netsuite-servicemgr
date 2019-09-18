using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Celigo.ServiceManager.NetSuite.TSA
{
    public interface TokenService
    {
        Task<RequestTokenResponse> GetRequestToken(string account, string callbackUrl);
        Task<AccessTokenResponse> GetAccessToken(string account, string requestToken, string tokenSecret, string verifier);
    }
}
