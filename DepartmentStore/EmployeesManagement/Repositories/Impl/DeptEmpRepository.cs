using EmployeesManagement.Models.entities;

namespace EmployeesManagement.Repositories.Impl
{
    public class DeptEmpRepository : IDeptEmpRepository
    {
        private readonly employeesContext _context;

        public DeptEmpRepository (employeesContext context)
        {
            _context = context;
        }

        public IEnumerable<DeptEmp> GetAll (int? empNo = null)
        {
            List<DeptEmp> result;

            if (empNo.HasValue)
            {
                result = _context.DeptEmps.Where (p => p.EmpNo == empNo.Value).ToList ();
            }
            else
            {
                result = _context.DeptEmps.ToList ();
            }

            return result;
        }
    }
}

