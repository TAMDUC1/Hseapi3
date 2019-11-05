using System;
using System.Collections.Generic;

namespace HseApi.Models
{
    public partial class Role
    {
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public bool? IsDefault { get; set; }
    }
}
