using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.Securities
{
    public class PKeys
    {
        public static RSAParameters ReadPrivateKeys()
        {
            var ByteConverter = new ASCIIEncoding();

            string[] lines2 = {
                                 "DEl7QHBrm1KbjixCRIHNP36wykJW2wmq9g3DdCXsQ/klQXlcnHxPvEnUs0hr7RSiysznPC76QGDyGAYOyU4LyXjhmDroV0FM3SXPzHZZf4PalpDwHxdN+L3CGGX4GWxWpFWNPTp9AmfCrWenGnzH6reScnb7hGr6JMwpkoVlOYE=",
                                 "ceKY/bF+c/zx+ZQPQQcKZo17Yxl5NFTZRg6opKL7MtaJWHzGaGkOYaOhNNxSXwvHofOxOdubLzpjPzS0Ru063w==",
                                 "w2uXsEisc285Fh+pFcfXZ2E8RgqWqap6cS+rs81wlhSL7rrixLUB4BSsxwOZD80GpyV43b2XIrEFbaT5fb1MQQ==",
                                 "AQAB",
                                 "IuGFvJXciRswLaK1ZFPLRjCE7M4BE4vtpDR+QlHaCa/A89QlRBaGQbtiObtyAtC97MP4XwX36sSc1K8XH2NB3g==",
                                 "sgkknY4C0MBgCX+LOMX4tycgX0OzGjw4z2wFULt7NiHqhvfpPQKPOx8+CiNi9utVfXbN+Ip3nXij96HAO5cDUZFYhXDkgllsofUc9/kr+NKhbCCdkUqaytv7XcPb2sFvE+Rq8kTuFB37tUs7LJ+6UO24l88Yh1yEyQIhu0UMf6M=",
                                 "1pQlmLqtko246DSk7dSdzvAcB+VrEDMW8pFRwZIG4zaiTvVEum/+jEArg/PV9JujRx0pSw4hoFFjs6mexdS44w==",
                                 "1GcmBxvXg5Esepm/pooiDihf6ifRlm638hVO9m5P6NuGkkH1Ux/oleqQJ88OdDIB1+VnwZC+AKeNBalB97uaQQ=="
                              };

            var RSAKeyInfo2 = new RSAParameters();
            int iCount = 0;
            foreach (string line in lines2)
            {
                iCount++;
                switch (iCount)
                {
                    case 1:
                        RSAKeyInfo2.D = Convert.FromBase64String(line);
                        break;

                    case 2:
                        RSAKeyInfo2.DP = Convert.FromBase64String(line);
                        break;

                    case 3:
                        RSAKeyInfo2.DQ = Convert.FromBase64String(line);
                        break;

                    case 4:
                        RSAKeyInfo2.Exponent = Convert.FromBase64String(line);
                        break;

                    case 5:
                        RSAKeyInfo2.InverseQ = Convert.FromBase64String(line);
                        break;

                    case 6:
                        RSAKeyInfo2.Modulus = Convert.FromBase64String(line);
                        break;

                    case 7:
                        RSAKeyInfo2.P = Convert.FromBase64String(line);
                        break;

                    case 8:
                        RSAKeyInfo2.Q = Convert.FromBase64String(line);
                        break;
                }
            }

            return RSAKeyInfo2;
        }
    }

    public sealed class PublicKey
    {
        private static readonly PublicKey instance_ = new PublicKey();

        private PublicKey()
        {
        }
        public static PublicKey Instance
        {
            get
            {
                return instance_;
            }
        }

        public RSAParameters ReadPublicKeys()
        {
            var ByteConverter = new ASCIIEncoding();

            string[] lines2 =  {
                                  "AQAB",
                                  "sgkknY4C0MBgCX+LOMX4tycgX0OzGjw4z2wFULt7NiHqhvfpPQKPOx8+CiNi9utVfXbN+Ip3nXij96HAO5cDUZFYhXDkgllsofUc9/kr+NKhbCCdkUqaytv7XcPb2sFvE+Rq8kTuFB37tUs7LJ+6UO24l88Yh1yEyQIhu0UMf6M="
                               };

            var RSAKeyInfo2 = new RSAParameters();
            int iCount = 0;
            foreach (string line in lines2)
            {
                iCount++;
                switch (iCount)
                {
                    case 1:
                        RSAKeyInfo2.Exponent = Convert.FromBase64String(line);
                        break;

                    case 2:
                        RSAKeyInfo2.Modulus = Convert.FromBase64String(line);
                        break;
                }
            }
            return RSAKeyInfo2;
        }
    }
}
