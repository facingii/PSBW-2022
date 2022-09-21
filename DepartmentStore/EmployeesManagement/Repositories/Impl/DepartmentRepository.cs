using EmployeesManagement.Models.entities;

namespace EmployeesManagement.Repositories.Impl
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly employeesContext _context;

        public DepartmentRepository (employeesContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll ()
        {
            var result = _context.Departments.ToList ();
            return result;
        }
    }
}

