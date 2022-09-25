using NUnit.Framework;
using EmployeesManagement.Services.Impl;
using EmployeesManagementTest.Mocks;

namespace EmployeesManagementTest;

public class Tests
{
    private EmployeesRepositoryMock employeesRepositoryMock;
    private DepartmentRepositoryMock departmentRepositoryMock;
    private DeptEmpRepositoryMock deptEmpMock;

    [SetUp]
    public void Setup()
    {
        employeesRepositoryMock = new EmployeesRepositoryMock();
        departmentRepositoryMock = new DepartmentRepositoryMock();
        deptEmpMock = new DeptEmpRepositoryMock();
    }

    [Test]
    public void GetEmployees ()
    {
        // setup
        var service = new EmployeeService (employeesRepositoryMock, departmentRepositoryMock, deptEmpMock);

        // act
        var result = service.Get (1000000);

        // assert
        Assert.That (result.LastName, Is.EqualTo ("Garcia"));
    }

    [Test]
    public void GetDepartmentAssigned ()
    {
        //setup
        var service = new EmployeeService (employeesRepositoryMock, departmentRepositoryMock, deptEmpMock);

        //act
        var result = service.GetDepartmentsAssignedTo (1000000).FirstOrDefault ();

        //assert
        Assert.That (result?.DeptNo, Is.EqualTo ("1024"));
    }
}
