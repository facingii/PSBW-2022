using EmployeesManagement.Models.entities;

namespace EmployeesManagement.Repositories
{
    public interface IDeptEmpRepository
    {
        public IEnumerable<DeptEmp> GetAll (int? empNo = null);
    }
}

