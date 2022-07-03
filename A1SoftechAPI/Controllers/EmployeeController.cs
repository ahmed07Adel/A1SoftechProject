using Core.Entities;
using Core.Interfaces;
using Core.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace A1SoftechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository=repository;
        }
        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await repository.GetAllEmployees());
            }
            catch (Exception)
            { 

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }
        [HttpGet("GetEmployeeById/{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var res = await repository.GetEmployeeByID(id);
                var employeeNetSalary = await repository.GetEmployeeNetSalary(id);
                //res.NetSalary = employeeNetSalary.Value;
                if (res == null)
                {
                    return NotFound();
                }
                return res;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
        }
        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var entity = new Employee
                {
                    Name = model.Name,
                    Salary = model.Salary,
                    Email = model.Email,
                    Mobile = model.Mobile,
                };
                
                const double PercentTaxValue = 0.1;
                double taxPaid = model.Salary * PercentTaxValue;
                var NetSalary = model.Salary - taxPaid;
                var res = await repository.CreateEmployee(entity);
                var EmployeeTaxentity = new EmployeeTax
                {
                    EmployeeId = res.Id,
                    NetSalary = (float)NetSalary,
                    Tax = (float)PercentTaxValue,
                };
                var CalulateTax = await repository.CalculateEmployeeTax(EmployeeTaxentity);
                return Ok(res); 
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Create data");
            }
        }
        [HttpPost("UpdateEmployee/{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee([FromBody] EmployeeViewModel employeeModel)
        {
            try
            {
                var Prod = await repository.GetEmployeeByID(employeeModel.Id);
                if (Prod == null)
                {
                    return NotFound($"this pgetroduct = {employeeModel.Id} Can not found");
                }
                var res= await repository.UpdateEmployee(employeeModel);
                const double PercentTaxValue = 0.1;
                double taxPaid = employeeModel.Salary * PercentTaxValue;
                var NetSalary = employeeModel.Salary - taxPaid;
                var EmployeeTaxentity = new EmployeeTax
                {
                    EmployeeId = employeeModel.Id,
                    NetSalary = (float)NetSalary,
                    Tax = (float)PercentTaxValue,
                };
               await repository.UpdateCalculateEmployeeTax(EmployeeTaxentity);
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                return await repository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
       
        
    }
}
