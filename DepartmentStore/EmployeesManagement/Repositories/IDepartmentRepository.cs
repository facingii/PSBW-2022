using EmployeesManagement.Models.entities;

namespace EmployeesManagement.Repositories
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAll ();
    }
}

