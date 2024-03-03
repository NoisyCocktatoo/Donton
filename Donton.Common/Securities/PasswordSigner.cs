using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.Securities
{
    public class PasswordSigner
    {

        private string userAndPass_;
        private string signature_;

        public PasswordSigner(string userAndPass)
        {
            userAndPass_ = userAndPass;
            this.SignPassword();
        }

        private void SignPassword()
        {
            var ByteConverter = new ASCIIEncoding();


            byte[] hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = ByteConverter.GetBytes(userAndPass_);
                hash = sha256.ComputeHash(data);
            }

            RSAParameters rsaParameterInfo = PKeys.ReadPrivateKeys();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.ImportParameters(rsaParameterInfo);

            RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(RSA);

            RSAFormatter.SetHashAlgorithm("SHA256");

            var SignatureByte = RSAFormatter.CreateSignature(hash);

            string[] Signature = {
                Convert.ToBase64String(SignatureByte)
            };

            signature_ = Signature[0];
        }

        public string GetSignature()
        {
            return signature_;
        }


    }
}
