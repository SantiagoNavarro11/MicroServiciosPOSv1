using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiciosPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // GET: api/Producto
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("GET: ProductoController");
        }
        // GET: api/Producto/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"GET: ProductoController with id {id}");
        }
        // POST: api/Producto
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok("POST: ProductoController");
        }
        // PUT: api/Producto/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok($"PUT: ProductoController with id {id}");
        }
        // DELETE: api/Producto/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"DELETE: ProductoController with id {id}");
        }
    }
}
