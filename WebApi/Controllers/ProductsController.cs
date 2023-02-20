using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("prods")]
    public class ProductsController : ControllerBase
    {
        private readonly List<Product> data;

        public ProductsController()
        {
            data = new List<Product> {
                new Product { Id=1, Name="Keyboard"},
                new Product { Id=2, Name="Mouse"}
            };
        }

        [HttpGet] // GET prods
        public ActionResult<List<Product>> GetProducts()
        {
            //return BadRequest();
            return data;
        }

        [HttpGet("{id:int}")] // GET prods/7
        public ActionResult<Product> GetProduct([FromRoute] int id)
        {
            if (id <= 0)
                return NotFound();

            var item = data.FirstOrDefault(x => x.Id == id);

            if (item is null)
                return NotFound();

            return item;
        }

        [HttpPost] // POST prods
        public IActionResult AddProduct(ProductDTO model)
        {
            data.Add(new Product {
                Name = model.Name,
                Price = model.Price,
                StatusID = model.IsActive ? Statuses.Active : Statuses.Inactive,
            });
            return new StatusCodeResult(StatusCodes.Status201Created);
        }

        [HttpPut("{id:int}")] // PUT prods/2
        public IActionResult AddProduct([FromBody] ProductDTO model, [FromRoute] int id)
        {
            return new StatusCodeResult(StatusCodes.Status202Accepted);
        }

        [HttpDelete("{id:int}")] // DELTE prods/2
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            return Ok();
        }

        //[HttpGet("{other:minlength(4)}")] // GET prods/bobo
        //public IActionResult GetProductByName(string other)
        //{
        //    return Ok(other);
        //}
    }
}
