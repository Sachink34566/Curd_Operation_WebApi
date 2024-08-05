using Curd_Dot_Net_Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Curd_Dot_Net_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRes _employeeRes;

        public EmployeeController(EmployeeRes employeeRes)
        {
            _employeeRes = employeeRes;
        }

        [HttpPost]

        public async Task<ActionResult> Addemployee([FromBody] Employee model)
        {
            await _employeeRes.AddEmployee(model);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployee()
        {
            var employeelist=await _employeeRes.GetAllEmployee();
            return Ok(employeelist);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var res = await _employeeRes.GetById(id);
            return Ok(res);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee model)
        {
            try
            {
                await _employeeRes.UpdateEmployee(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeRes.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}
