using EFCore_CRUD_Operation.Models;
using EFCore_CRUD_Operation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace EFCore_CRUD_Operation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmplyeeServices _employeeServices;

        public EmployeeController(EmplyeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpPost("api/employee")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRequestModel model)
        {
            var dataResult = await _employeeServices.CreateEmployee(model);
            return dataResult ? Ok() : BadRequest();
        }

        [HttpPut("api/employee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeRequestModel model)
        {
            var dataResult = await _employeeServices.UpdateEmployee(model);
            return dataResult ? Ok() : BadRequest();
        }

        [HttpGet("api/employee")]
        public async Task<IActionResult> GetEmployee()
        {
            return Ok(await _employeeServices.GetEmployeeList());
        }

        [HttpDelete("api/employee")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            return Ok(await _employeeServices.DeleteEmployee(Id));
        }
    }
}
