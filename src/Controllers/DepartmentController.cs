using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Get All Students");
        }

        [HttpGet(template:"{code}")]
        public async Task<IActionResult> GetA(string code)
        {
            return Ok("Get" + code + " department data");
        }

        [HttpPost]
        public async Task<IActionResult> Insert()
        {
            return Ok("Insert new department");
        }

        [HttpPut(template: "{code}")]
        public async Task<IActionResult> Update(string code)
        {
            return Ok("Update " + code + " department");
        }

        [HttpDelete(template: "{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            return Ok("Delete " + code + " department");
        }
    }
}
