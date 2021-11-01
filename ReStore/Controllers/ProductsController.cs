using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {

        // variable named with an underscore just to signify that it is a private field
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        // Getting a list of products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // Get a specific product
        [HttpGet("{id}")] // api/product/(id)
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
