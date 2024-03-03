using System;
using System.Collections.Generic;

namespace Donton.DataAccess.Models
{
    public partial class EmailService
    {
        public long EmailServiceId { get; set; }
        public string Domain { get; set; }
        public string Smtp { get; set; }
        public short? Port { get; set; }
        public string SenderName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? UseSSL { get; set; }
        public bool? CheckCertificateRevocation { get; set; }
        public long? CreateId { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? LastUpdateId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
