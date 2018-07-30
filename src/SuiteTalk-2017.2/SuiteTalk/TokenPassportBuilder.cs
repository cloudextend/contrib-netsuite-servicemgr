using System;
using System.Security.Cryptography;
using System.Text;

namespace SuiteTalk
{
    public interface ITokenPassportBuilder
    {
        TokenPassport Build(TbaUserToken userToken);
        TokenPassport Build(string accountNumber, string tokenId, string tokenSecret);
    }

    public class TbaUserToken
    {
#pragma warning disable IDE1006
        public string account { get; set; }
        public string token { get; set; }
        public string tokenSecret { get; set; }
#pragma warning restore IDE1006
    }

    public class DefaultTokenPassportBuilder: ITokenPassportBuilder
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;

        public DefaultTokenPassportBuilder(string consumerKey, string consumerSecret)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
        }

        public TokenPassport Build(TbaUserToken userToken) => this.Build(userToken.account, userToken.token, userToken.tokenSecret);

        public TokenPassport Build(string accountNumber, string token, string tokenSecret)
        {
            string nonce = this.ComputeNonce();
            long timestamp = this.ComputeTimestamp();
            var signature = this.ComputeSignature(accountNumber, token, tokenSecret, nonce, timestamp);

            return new TokenPassport {
                account = accountNumber,
                consumerKey = _consumerKey,
                nonce = nonce,
                signature = signature,
                timestamp = timestamp,
                token = token
            };
        }

        private string ComputeNonce()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] data = new byte[20];
            rng.GetBytes(data);
            int value = Math.Abs(BitConverter.ToInt32(data, 0));
            return value.ToString();
        }

        private long ComputeTimestamp()
        {
            return ((long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
        }

        private TokenPassportSignature ComputeSignature(string acctNumber, string tokenId, string tokenSecret, string nonce, long timestamp)
        {
            string baseString = $"{acctNumber}&{_consumerKey}&{tokenId}&{nonce}&{timestamp}";
            string key = string.Concat(_consumerSecret, "&", tokenSecret);
            string signature = "";

            var encoding = new ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes(key);
            byte[] baseStringBytes = encoding.GetBytes(baseString);
            using (var hmacSha1 = new HMACSHA1(keyBytes))
            {
                byte[] hashBaseString = hmacSha1.ComputeHash(baseStringBytes);
                signature = Convert.ToBase64String(hashBaseString);
            }
            TokenPassportSignature sign = new TokenPassportSignature {
                algorithm = "HMAC-SHA1",
                Value = signature
            };
            return sign;
        }
    }
}
