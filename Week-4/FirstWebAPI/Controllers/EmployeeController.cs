using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/emp")]
    public class EmployeeController : ControllerBase
    {
        private static List<string> employees = new List<string>
        {
            "Ayush","Aman","Ajay"
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Add([FromBody] string name)
        {
            employees.Add(name);
            return Ok("Added: "+name);
        }
    }
}
