using System;
using System.Collections.Generic;

namespace HseApi.Models
{
    public partial class FailedLogin
    {
        public long Id { get; set; }
        public Guid? UserUuid { get; set; }
        public int? IpAddress { get; set; }
        public int? Attempted { get; set; }
    }
}
