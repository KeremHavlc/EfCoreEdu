using EfCoreEdu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreEdu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfProductController : ControllerBase
    {
        DenemeContext context = new DenemeContext();

        [HttpGet("[action]")]
        public IActionResult GetProducts()
        {
            var result = context.Products.Max(p => p.Price);

            var result2 = context.Products.OrderByDescending(p => p.Id).FirstOrDefault();

            var list = context.Products.ToArray();

            var list2 = context.Products.AsQueryable();

            return Ok(list2);
        }
    }
}
