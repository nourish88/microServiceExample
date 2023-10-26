
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productApi.Context;
using productApi.Models;
using System.Runtime.Versioning;

namespace productApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Product.FirstOrDefaultAsync(x => x.Id == id);
            Guard.Against.Null(product);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _context.Product.FirstOrDefaultAsync(x => x.Id == id);

            if(product == null) { return NotFound(); }
            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Product.ToListAsync();
            if (!products.Any()) { return NotFound(); }
            return Ok(products);
        }
        [HttpGet("name")]
        public async Task<IActionResult> GetByName(string name)
        {
            var product = await _context.Product.FirstOrDefaultAsync(x => x.Name.StartsWith(name));
            if (product == null) { return NotFound(); }
            return Ok(product);

        }
        [HttpPost]
        public async Task<IActionResult> Create(productApi.Models.Product product)
        {
             await _context.Product.AddAsync(product);
            var effectedCounts =  await _context.SaveChangesAsync();
            if(effectedCounts>0)
            return Ok(product.Id);
            return BadRequest();

        }
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
                      
            
             _context.Product.Update(product);
            var effectedCounts = await _context.SaveChangesAsync();
            if (effectedCounts > 0)
                return Ok(product.Id);
            return BadRequest();

        }
    }
}
