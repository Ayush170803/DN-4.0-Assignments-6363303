using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController:ControllerBase
    {
        [HttpGet]
        public IActionResult Get()=>Ok(new[] {"Product"});

        [HttpGet("{id}")]
        public IActionResult GetById(int id)=>Ok("Product" + id);

        [HttpPost]
        public IActionResult Post([FromBody] string value) => Ok("Posted: " + value);

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value) => Ok($"Updated {id} to {value}");

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok($"Deleted value {id}");
    }
}
