using System.Text.Json.Serialization;

namespace EmployeesManagement.Models.entities
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
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<DeptEmp> DeptEmps { get; set; }

        [JsonIgnore]
        public virtual ICollection<DeptManager> DeptManagers { get; set; }

        [JsonIgnore]
        public virtual ICollection<Salary> Salaries { get; set; }

        [JsonIgnore]
        public virtual ICollection<Title> Titles { get; set; }
    }
}
