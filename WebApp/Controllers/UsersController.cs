using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("/users/{id?}")]
    public class UsersController : ControllerBase
    {
        private readonly RedisService RedisService;

        public UsersController(RedisService redisService)
        {
            RedisService = redisService;
        }


        [HttpGet]
        public IActionResult Get(string? id)
        {
            var db = RedisService.GetDb(2);
            return Ok("Get");
        }

        [HttpPost]
        public IActionResult Add([FromBody] User user)
        {      
            return Ok("Added");
        }

        [HttpPatch]
        public IActionResult Update([FromBody] User user)
        {
            
            return Ok("Updated");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            return Ok("Deleted");
        }
    }
}
