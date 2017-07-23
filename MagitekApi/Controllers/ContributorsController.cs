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
