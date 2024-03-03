using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.Securities
{
    public class PasswordVerifier
    {
        private string signatureText_;
        private bool retValue = false;

        public PasswordVerifier(string signatureText, string signature)
        {
            signatureText_ = signatureText;

            ASCIIEncoding ByteConverter = new ASCIIEncoding();
            RSAParameters rsaParameterInfo = PublicKey.Instance.ReadPublicKeys();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.ImportParameters(rsaParameterInfo);

            byte[] hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = ByteConverter.GetBytes(signatureText_);
                hash = sha256.ComputeHash(data);
            }

            var signatureByte = Convert.FromBase64String(signature);

            RSAPKCS1SignatureDeformatter RSADeformatter = new RSAPKCS1SignatureDeformatter(RSA);
            RSADeformatter.SetHashAlgorithm("SHA256");

            retValue = RSADeformatter.VerifySignature(hash, signatureByte) ? true : false;
        }

        public bool IsVerified
        {
            get
            {
                return retValue;
            }
        }
    }
}
