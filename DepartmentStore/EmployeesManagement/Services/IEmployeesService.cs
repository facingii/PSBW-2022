using EmployeesManagement.Models.entities;

namespace EmployeesManagement.Services
{
    public interface IEmployeesService
    {
        public IEnumerable<Employee> GetAll (int? index, int? take);
        public Employee Get (int empNo);
        public bool SaveEmployee (Employee employee);
        public bool UpdateEmployee (int empNo, Employee employee);
        public bool DeleteEmployee (int empNo);
        public IEnumerable<Department> GetDepartmentsAssignedTo (int empNo);
    }
}

