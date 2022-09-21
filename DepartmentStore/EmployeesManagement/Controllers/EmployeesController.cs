using System.Text.Json;
using EmployeesManagement.Models.entities;
using EmployeesManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManagement.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeesService _employeesService;

        public EmployeesController (ILogger<EmployeesController> logger, IEmployeesService employeesService)
        {
            _logger = logger;
            _employeesService = employeesService;
        }

        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (IEnumerable<Employee>))]
        public IEnumerable<Employee> GetAllEmployees ()
        {
            _logger.LogInformation ("Getting All Employees Info");
            var result = _employeesService.GetAll (0, 1000);

            return result;
        }

        [HttpGet ("{empNo}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof (Employee))]
        public Employee GetEmployee (int empNo)
        {
            _logger.LogInformation ($"Getting Info for Employee No = {empNo}" );

            var result = _employeesService.Get (empNo);
            if (result == null) return new Employee ();

            return result;
        }

        [HttpGet ("assigned/{empNo}")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (IEnumerable<Employee>))]
        public IEnumerable<Department> GetDepartmentAssigned (int empNo)
        {
            _logger.LogInformation ($"Getting Departments assigned to employee number = {empNo}");

            var result = _employeesService.GetDepartmentsAssignedTo (empNo);
            return result;
        }

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult AddEmployee ([FromBody] Employee employee)
        {
            try
            {
                var saved = _employeesService.SaveEmployee (employee);

                if (!saved)
                    return BadRequest ("Some information is missing");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError ($"An error was raised in {nameof (EmployeesController)}.{nameof (AddEmployee)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { JsonSerializer.Serialize (employee) });

                throw;
            }
        }

        [HttpPut ("{empNo}")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateEmployee (int empNo, [FromBody] Employee employee)
        {
            return null;
        }

    }

}



