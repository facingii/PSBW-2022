using System;
using System.Collections.Generic;

namespace EntiityFramworkFundamentals.Models
{
    public partial class Employee
    {
        public Employee()
        {
            DeptEmps = new HashSet<DeptEmp>();
            DeptManagers = new HashSet<DeptManager>();
            Salaries = new HashSet<Salary>();
            Titles = new HashSet<Title>();
        }

        public int EmpNo { get; set; }
        public DateOnly BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateOnly HireDate { get; set; }

        public virtual ICollection<DeptEmp> DeptEmps { get; set; }
        public virtual ICollection<DeptManager> DeptManagers { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<Title> Titles { get; set; }
    }
}
