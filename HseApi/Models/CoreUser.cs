using System;
using System.Collections.Generic;

namespace HseApi.Models
{
    public partial class CoreUser
    {
        public Guid Uuid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Activation { get; set; }
        public string Data { get; set; }
        public string Acl { get; set; }
        public short? Status { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? LoggedOn { get; set; }
        public string LoggedIp { get; set; }
        public string PasswordMobile { get; set; }
    }
}
