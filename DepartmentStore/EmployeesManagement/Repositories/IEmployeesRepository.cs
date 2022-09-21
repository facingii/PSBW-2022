using EmployeesManagement.Models.entities;

namespace EmployeesManagement.Repositories
{
    public interface IEmployeesRepository
    {
        public IEnumerable<Employee> GetAll (int? index, int? take);
        public Employee Get (int empNo);
        public bool Save (Employee employee);
        public bool Update (int empNo, Employee employee);
        public bool Delete (int empNo);
    }
}

