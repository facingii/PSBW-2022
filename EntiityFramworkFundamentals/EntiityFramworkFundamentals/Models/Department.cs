using System;
using System.Collections.Generic;

namespace EntiityFramworkFundamentals.Models
{
    public partial class Department
    {
        public Department()
        {
            DeptEmps = new HashSet<DeptEmp>();
            DeptManagers = new HashSet<DeptManager>();
        }

        public string DeptNo { get; set; }
        public string DeptName { get; set; }

        public virtual ICollection<DeptEmp> DeptEmps { get; set; }
        public virtual ICollection<DeptManager> DeptManagers { get; set; }
    }
}
