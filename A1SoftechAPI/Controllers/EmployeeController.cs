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
        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<Employee>> CreateEmployee([FromForm] EmployeeViewModel model)
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
                var res = await repository.CreateEmployee(entity);
                return res;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Create data");
            }
        }
    }
}
