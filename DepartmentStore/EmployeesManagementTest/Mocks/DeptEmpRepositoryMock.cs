using System;
using EmployeesManagement.Models.entities;
using EmployeesManagement.Repositories;

namespace EmployeesManagementTest.Mocks
{
    public class DeptEmpRepositoryMock : IDeptEmpRepository
    {
        public DeptEmpRepositoryMock ()
        {
        }

        public IEnumerable<DeptEmp> GetAll (int? empNo = null)
        {
            return new List<DeptEmp> {
                new DeptEmp
                {
                     DeptNo = "1024",
                     EmpNo = 1000000
                }
            };
        }
    }
}

