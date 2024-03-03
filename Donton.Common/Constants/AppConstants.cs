using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.Constants
{
    public class AppConstants
    {
        public const string MailDomain = "donton";
#if DEBUG
        public const string MailServiceApi = "http://mail.vctcurve.online/api/Mail/sendmail";
#else
        public const string MailServiceApi = "http://mail.vctcurve.online/api/Mail/sendmail";
#endif
    }
}
