using System;
using System.Collections.Generic;

namespace HseApi.Models
{
    public partial class Access
    {
        public Guid Uuid { get; set; }
        public string Object { get; set; }
        public string Action { get; set; }
        public Guid? RoleUuid { get; set; }
        public string Value { get; set; }
    }
}
