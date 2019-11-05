using System;
using System.Collections.Generic;

namespace HseApi.Models
{
    public partial class SuccessLogin
    {
        public int Id { get; set; }
        public Guid? UserUuid { get; set; }
        public int? IpAddress { get; set; }
        public string UserAgent { get; set; }
    }
}
