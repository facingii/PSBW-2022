using System;
using System.Collections.Generic;

namespace EntiityFramworkFundamentals.Models
{
    public partial class Title
    {
        public int EmpNo { get; set; }
        public string Title1 { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly? ToDate { get; set; }

        public virtual Employee EmpNoNavigation { get; set; }
    }
}
