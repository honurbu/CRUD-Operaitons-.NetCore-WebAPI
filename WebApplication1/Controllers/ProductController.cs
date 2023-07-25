using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Entites;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        AppDbContext context;

        public ProductController(AppDbContext context)
        {
            this.context = context;
        }



        [HttpGet]
        public async Task<IActionResult> GetProdct()
        {
            var values = await context.Products.ToListAsync();
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return Ok("Successfully Added !");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await context.Products.FindAsync(id);
            if (values != null)
            {
                return Ok(values);

            }
            else
                return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var values = await context.Products.FindAsync(id);
            if (values != null)
            {
                context.Products.Remove(values);
                context.SaveChanges();
                return Ok("Successfully Removed !");
            }
            else
                return NotFound();
        }
    }
}
