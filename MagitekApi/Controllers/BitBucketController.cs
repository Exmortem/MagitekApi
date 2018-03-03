using System;
using System.Threading.Tasks;
using MagitekApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace MagitekApi.Controllers
{
    [Route("[controller]")]
    public class BitBucketController : Controller
    {
        private readonly IDistributedCache _redisCache;

        public BitBucketController(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBosses([FromBody] string message)
        {
            Console.WriteLine(message);
            return new OkResult();
        }
    }
}
