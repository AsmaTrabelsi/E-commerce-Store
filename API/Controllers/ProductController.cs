using API.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly StoreContext context; 
        public ProductController(StoreContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts()
        {
           return await  context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await context.Products.FindAsync(id);
        }
    }
}
