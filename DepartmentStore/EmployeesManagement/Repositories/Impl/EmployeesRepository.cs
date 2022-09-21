using EmployeesManagement.Models.entities;

namespace EmployeesManagement.Repositories.Impl
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly employeesContext _context;

        public EmployeesRepository (employeesContext context)
        {
            _context = context;
        }

        public Employee Get (int empNo)
        {
            var result = _context.Employees.FirstOrDefault (e => e.EmpNo == empNo);
            return result;
        }

        public IEnumerable<Employee> GetAll (int? index, int? take)
        {
            var result = _context.Employees.
                Skip (index.HasValue ? index.Value : 0)
                .Take (take.HasValue ? take.Value : 100);

            return result;
        }

        public bool Save (Employee employee)
        {
            var transaction = _context.Database.BeginTransaction ();

            try
            {
                var tempEmp = new Employee
                {
                    EmpNo = employee.EmpNo,
                };

                _context.Employees.Add (employee);

                foreach (var title in employee.Titles)
                {
                    _context.Titles.Add (title);
                }

                foreach (var s in employee.Salaries)
                {
                    _context.Salaries.Add (s);
                }

                foreach (var deptemp in employee.DeptEmps)
                {
                    _context.DeptEmps.Add (deptemp);
                }

                _context.SaveChanges ();
                transaction.Commit ();

                return true;
            }
            catch 
            {
                transaction.Rollback ();
                throw;
            }
        }

        public bool Update(int empNo, Employee employee)
        {
            throw new NotImplementedException ();
        }

        public bool Delete (int empNo)
        {
            var entity = _context.Employees.FirstOrDefault (e => e.EmpNo == empNo);
            if (entity == null) return false;

            _context.Remove (entity);
            _context.SaveChanges ();

            return true;
        }
    }
}

