using System;
using EmployeesManagement.Models.entities;
using EmployeesManagement.Repositories;

namespace EmployeesManagementTest.Mocks
{
    public class DepartmentRepositoryMock : IDepartmentRepository
    {
        public DepartmentRepositoryMock ()
        {
        }

        public IEnumerable<Department> GetAll ()
        {
            return new List<Department> {
                new Department
                {
                    DeptName = "Development",
                    DeptNo = "1024"
                }
            };
        }
    }
}

