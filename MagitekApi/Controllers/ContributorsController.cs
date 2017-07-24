using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagitekApi.Database;
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
                _redisCache.SetString(contributor.SecretKey, contributor.Name);
            }
        }

        #region GET

        [HttpGet("verify/{secretKey}")]
        public async Task<IActionResult> Verify(string secretKey)
        {
            Contributor contributor;

            var exists  = _redisCache.GetString(secretKey);
            Console.WriteLine($@"Does Key Exist? {exists}");

            using (var context = MagitekContextFactory.Create())
            {
                contributor = await context.Contributors.FirstOrDefaultAsync(r => r.SecretKey == secretKey);
            }

            if (contributor == null)
            {
                return new BadRequestObjectResult(new MagitekApiResult() { Name = "Failure", Description = $"Key Is Not Valid" });
            }

            return new ObjectResult(contributor);
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

            _redisCache.SetString(contributor.SecretKey, contributor.Name);

            return new ObjectResult(contributor);
        }
        #endregion
    }
}
