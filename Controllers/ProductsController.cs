using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<string> Products = new()
        {
            "Laptop",
            "Phone",
            "Tablet"
        };

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAllProducts()
        {
            return Ok(Products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public ActionResult<string> GetProductById(int id)
        {
            if (id < 0 || id >= Products.Count)
            {
                return NotFound("Product not found");
            }

            return Ok(Products[id]);
        }

        // POST: api/products
        [HttpPost]
        public ActionResult AddProduct([FromBody] string product)
        {
            Products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = Products.Count - 1 }, product);
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            if (id < 0 || id >= Products.Count)
            {
                return NotFound("Product not found");
            }

            Products.RemoveAt(id);
            return NoContent();
        }
    }
}