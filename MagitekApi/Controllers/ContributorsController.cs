using System;
using System.Threading.Tasks;
using MagitekApi.Database;
using MagitekApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagitekApi.Controllers
{
    [Route("/api/[controller]")]
    public class ContributorsController : Controller
    {
        private const string PassKey = "dwnklqwddkwnVHWLWMZBuamdmsakOQWLkXbx";

        #region GET

        [HttpGet("verify/{secretKey}")]
        public async Task<IActionResult> Verify(string secretKey)
        {
            Contributor contributor;

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

            return new ObjectResult(contributor);
        }
        #endregion
    }
}
