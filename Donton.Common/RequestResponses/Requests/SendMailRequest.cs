using Donton.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donton.Common.RequestResponses.Requests
{
    public class SendMailRequest
    {
        public SendMailRequest()
        {
            this.Domain = AppConstants.MailDomain;
            this.ToEmails = new List<Recipient>();
            this.Bccs = new List<Recipient>();
        }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string SenderName { get; set; }

        public string Domain { get; set; }

        public string FromEmail { get; set; }

        public List<Recipient> ToEmails { get; set; }
        public List<Recipient> Bccs { get; set; }
    }

    public class Recipient
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
