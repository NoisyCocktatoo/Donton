﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donton.DataAccess.Models
{
    public partial class spContactListResult
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