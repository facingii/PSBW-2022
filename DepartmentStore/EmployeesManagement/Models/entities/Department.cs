using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EmployeesManagement.Models.entities
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

        [JsonIgnore]
        public virtual ICollection<DeptEmp> DeptEmps { get; set; }

        [JsonIgnore]
        public virtual ICollection<DeptManager> DeptManagers { get; set; }
    }
}
