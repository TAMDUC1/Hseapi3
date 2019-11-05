using System;
using System.Collections.Generic;

namespace HseApi.Models
{
    public partial class RememberToken
    {
        public int Id { get; set; }
        public Guid? UserUuid { get; set; }
        public string Token { get; set; }
        public string UserAgent { get; set; }
        public int? CreatedAt { get; set; }
    }
}
