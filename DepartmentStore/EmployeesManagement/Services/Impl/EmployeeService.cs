using EmployeesManagement.Models.entities;
using EmployeesManagement.Repositories;

namespace EmployeesManagement.Services.Impl
{
    public class EmployeeService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDeptEmpRepository _deptEmpRepository;

        public EmployeeService (IEmployeesRepository employeesRepository,
            IDepartmentRepository departmentRepository,
            IDeptEmpRepository deptEmpRepository)
        {
            _employeesRepository = employeesRepository;
            _departmentRepository = departmentRepository;
            _deptEmpRepository = deptEmpRepository;

        }

        public Employee Get (int empNo)
        {
            return _employeesRepository.Get (empNo);
        }

        public IEnumerable<Employee> GetAll (int? index, int? take)
        {
            var result = _employeesRepository.GetAll (index, take);
            return result;
        }

        public bool SaveEmployee (Employee employee)
        {
            // validate required relations
            //if (!employee.DeptEmps.Any () || !employee.Titles.Any () || !employee.Salaries.Any ())
            //    return false;

            return true; //_employeesRepository.Save (employee);
        }

        public bool UpdateEmployee (int empNo, Employee employee)
        {
            return _employeesRepository.Update (empNo, employee);
        }

        public bool DeleteEmployee (int empNo)
        {
            throw new NotImplementedException ();
        }

        public IEnumerable<Department> GetDepartmentsAssignedTo (int empNo)
        {
            var departments = _departmentRepository.GetAll ();
            var deptEmps = _deptEmpRepository.GetAll (empNo);

            var assigned = from de in deptEmps where de.EmpNo == empNo
                           join d in departments on de.DeptNo equals d.DeptNo select d;

            return assigned.ToList ();
        }
    }
}

