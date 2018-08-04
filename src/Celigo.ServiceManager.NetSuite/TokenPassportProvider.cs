using SuiteTalk;

namespace Celigo.ServiceManager.NetSuite
{
    public interface ITokenPassportProvider
    {
        TokenPassport GetTokenPassport();
    }

    public interface ITokenPassportManager: ITokenPassportProvider
    {
        TbaUserToken UserToken { get; set; }
    }

    public class DefaultTokenPassportManager: ITokenPassportManager
    {
        private readonly ITokenPassportBuilder _passportBuilder;

        public TbaUserToken UserToken { get; set; }

        public DefaultTokenPassportManager(string consumerKey, string consumerSecret)
            : this(new DefaultTokenPassportBuilder(consumerKey, consumerSecret)) {}

        public DefaultTokenPassportManager(ITokenPassportBuilder passportBuilder)
        {
            _passportBuilder = passportBuilder;
        }

        public DefaultTokenPassportManager(ITokenPassportBuilder passportBuilder, TbaUserToken userToken): this(passportBuilder)
        {
            this.UserToken = userToken;
        }

        public TokenPassport GetTokenPassport() =>_passportBuilder.Build(this.UserToken.account, this.UserToken.token, this.UserToken.tokenSecret);
    }
}
