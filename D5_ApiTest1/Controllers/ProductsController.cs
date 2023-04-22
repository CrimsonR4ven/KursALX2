using D5_ApiTest1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D5_ApiTest1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Products> products = new List<Products>()
        {
            new Products{ Id = 1,Name="Cola", Description="1L",Price=10.99M},
            new Products{ Id = 2,Name="Chipsy", Description="Małe",Price=16.78M},
            new Products{ Id = 3,Name="Kluski",Price=5.99M}
        };
        [HttpGet]
        public ActionResult<IEnumerable<Products>> Get()
        {
            return products;
        }

        // GET /api/Values/x
        [HttpGet("{id}")]
        public ActionResult<Products> Get(int id)
        {
            Products product = products.Find(x => x.Id == id);
            if (product == null)
            {
                return StatusCode(418);
            }
            return product;
        }

        // POST /api/Values
        [HttpPost]
        public ActionResult<Products> Post([FromBody] Products newProduct)
        {
            if(newProduct.Id != 0)
            {
                products.Add(newProduct);
                return CreatedAtAction(nameof(Post), new { id = newProduct.Id }, newProduct);
            }
            else
            {
                return StatusCode(418);
            }
        }

        // DELETE /api/Values/x
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
            {
                return StatusCode(418);
            }
            products.Remove(product);
            return NoContent();
        }
            

        // PUT /api/Values/x
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Products updatedProduct)
        {
            var product = products.Find(x => x.Id == updatedProduct.Id);
            if (product == null)
            {
                return StatusCode(418);
            }
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            return NoContent();
        }
    }
}
