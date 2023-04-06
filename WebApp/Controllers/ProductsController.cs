using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("/products/{id?}")]
    public class ProductsController : ControllerBase
    {
        private readonly IDistributedCache DistributedCache;
        private readonly DistributedCacheEntryOptions CacheOptions;

        public ProductsController(IDistributedCache _distributedCache)
        {
            DistributedCache = _distributedCache;
            CacheOptions = new DistributedCacheEntryOptions { 
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5),
            };
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            var product = DistributedCache.GetString($"product:{id}") ?? "Not found";
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            DistributedCache.SetString($"product:{product.Id}", json, CacheOptions);
            return Ok("Added");
        }

        [HttpPatch]
        public IActionResult Update([FromBody] Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            DistributedCache.SetString($"product:{product.Id}", json, CacheOptions);
            return Ok("Update");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            DistributedCache.Remove($"product:{id}");
            return Ok("Delete");
        }
    }
}
