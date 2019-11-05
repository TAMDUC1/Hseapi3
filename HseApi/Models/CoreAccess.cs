﻿using System;
using System.Collections.Generic;

namespace HseApi.Models
{
    public partial class CoreAccess
    {
        public Guid Uuid { get; set; }
        public string Data { get; set; }
        public string Workflow { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
