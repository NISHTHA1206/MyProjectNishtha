using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingInASPNETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/products
        [HttpGet("api/products")]
        public IActionResult GetAllProducts()
        {
            // Logic to get all products
            return Ok(new List<string> { "Product1", "Product2" });
        }
        // GET api/products/{id}
        [HttpGet("api/products/{id}")]
        public IActionResult GetProductById(int id)
        {
            // Logic to get a product by id
            return Ok($"Product{id}");
        }
        // POST api/products
        [HttpPost("api/products")]
        public IActionResult CreateProduct([FromBody] string product)
        {
            // Logic to create a new product
            return CreatedAtAction(nameof(GetProductById), new { id = 1 }, product);
        }
        // PUT api/products/{id}
        [HttpPut("api/products/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] string product)
        {
            // Logic to update a product
            return NoContent();
        }
        // DELETE api/products/{id}
        [HttpDelete("api/products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            // Logic to delete a product
            return NoContent();
        }
    }

}

