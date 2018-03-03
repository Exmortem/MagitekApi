using System;
using System.Threading.Tasks;
using MagitekApi.Database;
using MagitekApi.Extensions;
using MagitekApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace MagitekApi.Controllers
{
    [Route("[controller]")]
    public class BossesController : Controller
    {
        private readonly IDistributedCache _redisCache;

        public BossesController(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        [HttpGet("verify/{secretKey}")]
        public async Task<IActionResult> GetAllBosses(string secretKey)
        {
            var contributor = _redisCache.Get(secretKey).FromByteArray<Contributor>();

            if (contributor != null)
            {
                Console.WriteLine($"Got {contributor.Name} from Redis Cache");
                return new ObjectResult(contributor);
            }

            using (var context = MagitekContextFactory.Create())
            {
                contributor = await context.Contributors.FirstOrDefaultAsync(r => r.SecretKey == secretKey);
            }

            return contributor == null ?
                new BadRequestObjectResult(new MagitekApiResult() { Name = "Failure", Description = $"Key Is Not Valid" }) :
                new ObjectResult(contributor);
        }
    }
}
