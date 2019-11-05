using System;
using System.Collections.Generic;

namespace HseApi.Models
{
    public partial class HseQr
    {
        public Guid Uuid { get; set; }
        public string Data { get; set; }
        public string DataArr { get; set; }
        public string Attachment { get; set; }
        public string Workflow { get; set; }
        public short? Status { get; set; }
        public short? Year { get; set; }
        public short? Quarter { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public short? Kind { get; set; }
        public int? CompanyId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
