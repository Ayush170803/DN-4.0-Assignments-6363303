using Microsoft.AspNetCore.Mvc;
using FirstWebAPI.Models;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeInfoController:ControllerBase
    {
        private static List<Employee> _employees = new()
        {
            new Employee
            {
                Id=101,
                Name="Anant",
                Salary=55000,
                Permanent=true,
                Department=new Department {Id=1,Name="HR"},
                Skills = new List<Skill>
                {
                    new Skill {Id=1,Name="C#"},
                    new Skill {Id=2,Name="SQL"}
                },
                DateOfBirth=new DateTime(2004,11,26)
            }
        };

        [HttpGet]
        public ActionResult<List<Employee>> Get() => Ok(_employees);

        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            _employees.Add(emp);
            return Ok("Employee added.");
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmp)
        {
            if(id<=0)
                return BadRequest("Invalid employee id");

            var emp=_employees.FirstOrDefault(e => e.Id == id);
            if (emp==null)
                return BadRequest("Invalid employee id");

            emp.Name=updatedEmp.Name;
            emp.Salary=updatedEmp.Salary;
            emp.Permanent=updatedEmp.Permanent;
            emp.Department=updatedEmp.Department;
            emp.Skills=updatedEmp.Skills;
            emp.DateOfBirth=updatedEmp.DateOfBirth;
            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp=_employees.FirstOrDefault(e => e.Id == id);
            if (emp==null)
                return BadRequest("Invalid employee id");
            _employees.Remove(emp);
            return Ok($"Employee with id {id} deleted.");
        }
    }
}
