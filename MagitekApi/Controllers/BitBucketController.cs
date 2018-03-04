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
        public BitBucketController(IDistributedCache redisCache)
        {

        }

        [HttpPost("")]
        public async Task<IActionResult> ReceiveMessage([FromBody] BitBucketMessage message)
        {
            Console.WriteLine($@"{message.DisplayName} Commited: {message.Commit}");
            return new OkResult();
        }
    }
}
