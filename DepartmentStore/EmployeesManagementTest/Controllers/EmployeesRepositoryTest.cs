using System;
using EmployeesManagement.Models.entities;
using EmployeesManagement.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace EmployeesManagementTest.Controllers
{
    public class EmployeesRepositoryTest
    {
        private IQueryable<Employee> data;

        [SetUp]
        public void Initialize ()
        {
            data = new List<Employee>
            {
                new Employee
                {
                    EmpNo = 1,
                    FirstName = "John",
                    LastName = "Snow",
                    Gender = "M",
                    BirthDate = new DateTime (1995, 08, 12)
                },
                new Employee
                {
                    EmpNo = 2,
                    FirstName = "Daenarys",
                    LastName = "Targaryen",
                    Gender = "F",
                    BirthDate = new DateTime (2000, 04, 21)
                },
                new Employee
                {
                    EmpNo = 3,
                    FirstName = "Tyrion",
                    LastName = "Lannister",
                    Gender = "M",
                    BirthDate = new DateTime (1990, 02, 07)

                }
            }.AsQueryable();
        }

        [Test]
        public void GetAllTest ()
        {
            //setup
            var employeesSetMock = new Mock<DbSet<Employee>>();
            employeesSetMock.As<IQueryable<Employee>>().Setup (m => m.Provider).Returns (data.Provider);
            employeesSetMock.As<IQueryable<Employee>>().Setup (m => m.Expression).Returns (data.Expression);
            employeesSetMock.As<IQueryable<Employee>>().Setup (m => m.ElementType).Returns (data.ElementType);
            employeesSetMock.As<IQueryable<Employee>>().Setup (m => m.GetEnumerator ()).Returns (() => data.GetEnumerator ());

            var employeesContextMock = new Mock<employeesContext>();
            employeesContextMock.Setup (c => c.Employees).Returns (employeesSetMock.Object);

            var employeeRepository = new EmployeesRepository (employeesContextMock.Object);

            //act
            var result = employeeRepository.GetAll (0, 3);

            //assert
            Assert.IsNotEmpty (result);
        }

        [Test]
        public void GetEmployeeTest ()
        {
            //setup
            var employeesSetMock = new Mock<DbSet<Employee>>();
            employeesSetMock.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            employeesSetMock.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            employeesSetMock.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            employeesSetMock.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var employeesContextMock = new Mock<employeesContext>();
            employeesContextMock.Setup (c => c.Employees).Returns (employeesSetMock.Object);

            var employeeRepository = new EmployeesRepository (employeesContextMock.Object);

            //act
            var result = employeeRepository.Get (3);

            //assert
            Assert.That (result.FirstName, Is.EqualTo ("Tyrion"));
        }


        [Test]
        public void UpdateEmployeeTest ()
        {
            //setup
            //employee object updated
            var employee = new Employee //employee object updated
            {
                EmpNo = 2,
                FirstName = "Dany",
                LastName = "Targaryen",
                Gender = "F",
                BirthDate = new DateTime (2000, 04, 21)
            };

            var employeesSetMock = new Mock<DbSet<Employee>>();
            employeesSetMock.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            employeesSetMock.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            employeesSetMock.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            employeesSetMock.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var employeesContextMock = new Mock<employeesContext>();
            employeesContextMock.Setup (c => c.Employees).Returns (employeesSetMock.Object);

            var employeeRepository = new EmployeesRepository (employeesContextMock.Object);

            //act
            var result = employeeRepository.Update (2, employee);

            //assert
            employeesSetMock.Verify (e => e.Update (It.IsAny<Employee> ()), Times.Once ());
            employeesContextMock.Verify (c => c.SaveChanges (), Times.Once ());
            Assert.IsTrue (result);
        }

        [Test]
        public void DeleteEmployeeTest ()
        {
            //setup
            var employeesSetMock = new Mock<DbSet<Employee>>();
            employeesSetMock.As<IQueryable<Employee>>().Setup (m => m.Provider).Returns (data.Provider);
            employeesSetMock.As<IQueryable<Employee>>().Setup (m => m.Expression).Returns (data.Expression);
            employeesSetMock.As<IQueryable<Employee>>().Setup (m => m.ElementType).Returns (data.ElementType);
            employeesSetMock.As<IQueryable<Employee>>().Setup (m => m.GetEnumerator()).Returns (() => data.GetEnumerator ());
             
            var employeesContextMock = new Mock<employeesContext>();
            employeesContextMock.Setup (c => c.Employees).Returns (employeesSetMock.Object);

            var employeeRepository = new EmployeesRepository (employeesContextMock.Object);

            //act
            var result = employeeRepository.Delete (1);

            //assert
            employeesSetMock.Verify (e => e.Remove (It.IsAny<Employee>()), Times.Once ());
            employeesContextMock.Verify (c => c.SaveChanges (), Times.Once ());
            Assert.IsTrue (result);
        }
    }
}

