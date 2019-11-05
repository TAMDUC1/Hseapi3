using System;
using System.Collections.Generic;

namespace HseApi.Models
{
    public partial class CmsContactForm
    {
        public Guid Uuid { get; set; }
        public string Data { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
