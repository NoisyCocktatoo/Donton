using System;
using System.Collections.Generic;

namespace Donton.DataAccess.Models
{
    public partial class Contact
    {
        public long ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public string ProfileImage { get; set; }
        public long? CreateId { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? LastUpdateId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
