
using System;
using EmployeesManagement.Models.entities;
using EmployeesManagement.Repositories;

namespace EmployeesManagementTest.Mocks
{
    public class EmployeesRepositoryMock : IEmployeesRepository 
    {
        public EmployeesRepositoryMock()
        {
        }

        public bool Delete(int empNo)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int empNo)
        {

            return new Employee
            {
                EmpNo = 1000000,
                LastName = "Garcia",
                FirstName = "Oscar",
                BirthDate = new DateTime(1996, 07, 21)
            };
        }

        public IEnumerable<Employee> GetAll(int? index, int? take)
        {
            throw new NotImplementedException();
        }

        public bool Save(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool Update(int empNo, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}

