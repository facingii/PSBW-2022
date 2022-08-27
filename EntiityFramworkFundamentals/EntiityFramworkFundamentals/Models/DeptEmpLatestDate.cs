using System;
using System.Collections.Generic;

namespace EntiityFramworkFundamentals.Models
{
    public partial class DeptEmpLatestDate
    {
        public int EmpNo { get; set; }
        public DateOnly? FromDate { get; set; }
        public DateOnly? ToDate { get; set; }
    }
}
