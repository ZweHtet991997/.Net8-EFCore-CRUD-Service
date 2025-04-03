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

        #region SingleOperations

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

        #endregion

        #region BulkOperations

        [HttpPost("api/bulk/employee")]
        public async Task<IActionResult> BulkCreateEmployee([FromBody] List<EmployeeRequestModel> employeeList)
        {
            var dataResult = await _employeeServices.BulkCreateEmployeeAsync(employeeList);
            return dataResult ? Ok() : BadRequest();
        }

        [HttpPut("api/bulk/employee")]
        public async Task<IActionResult> BulkUpdateEmployee([FromBody] List<EmployeeRequestModel> employeeList)
        {
            var dataResult = await _employeeServices.BulkUpdateEmployeeAsync(employeeList);
            return dataResult ? Ok() : BadRequest();
        }

        [HttpDelete("api/bulk/employee")]
        public async Task<IActionResult> BulkDeleteEmployee(string department)
        {
            var dataResult = await _employeeServices.BulkDeleteEmployeeAsync(department);
            return dataResult ? Ok() : BadRequest();
        }

        #endregion
    }
}
