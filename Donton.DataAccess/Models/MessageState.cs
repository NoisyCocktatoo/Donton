using System;
using System.Collections.Generic;

namespace Donton.DataAccess.Models
{
    public partial class MessageState
    {
        public long MessageStateId { get; set; }
        public long? CreateId { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? LastUpdateId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
