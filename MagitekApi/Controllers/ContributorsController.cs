using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagitekApi.Database;
using MagitekApi.Extensions;
using MagitekApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace MagitekApi.Controllers
{
    [Route("/api/[controller]")]
    public class ContributorsController : Controller
    {
        private const string PassKey = "dwnklqwddkwnVHWLWMZBuamdmsakOQWLkXbx";
        private readonly IDistributedCache _redisCache;

        public ContributorsController(IDistributedCache redisCache)
        {
            _redisCache = redisCache;

            List<Contributor> contributors;

            using (var context = MagitekContextFactory.Create())
            {
                contributors = context.Contributors.ToList();
            }

            foreach (var contributor in contributors)
            {
                var byteArray = contributor.GetByteArray();
                _redisCache.Set(contributor.SecretKey, byteArray);
            }
        }

        #region GET
        [HttpGet("verify/{secretKey}")]
        public async Task<IActionResult> Verify(string secretKey)
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
        #endregion

        #region POST
        [HttpPost("add/{password}")]
        public async Task<IActionResult> Add([FromBody] Contributor contributor, string password)
        {
            if (password != PassKey)
            {
                return new ObjectResult(new MagitekApiResult() { Name = "Failure", Description = "Failure: Wrong Password" });
            }

            using (var context = MagitekContextFactory.Create())
            {
                if (await context.Contributors.AnyAsync(r => r.Name == contributor.Name))
                {
                    return new ObjectResult(new MagitekApiResult() { Name = "Failure", Description = "Failure: Duplicate Contributor" });
                }

                Console.WriteLine($"New Contributor [{contributor.Name}]");
                contributor.SecretKey = Guid.NewGuid().ToString();

                await context.AddAsync(contributor);
                await context.SaveChangesAsync();
            }

            var byteArray = contributor.GetByteArray();
            _redisCache.Set(contributor.SecretKey, byteArray);

            return new ObjectResult(contributor);
        }
        #endregion
    }
}
