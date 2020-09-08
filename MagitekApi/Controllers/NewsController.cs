using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using MagitekApi.Database;
using MagitekApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagitekApi.Controllers
{
    [Route("[controller]")]
    public class NewsController : Controller
    {
        // random passkey
        private const string PassKey = "";

        #region GET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<News> magitekNewsList;

            using (var context = MagitekContextFactory.Create())
            {
                magitekNewsList = await context.News.ToListAsync();
            }

            return new OkObjectResult(magitekNewsList); 
        }
        #endregion

        #region POST
        [HttpPost("{password}")]
        public async Task<IActionResult> Add([FromBody] News news, string password)
        {
            if (password != PassKey)
            {
                return new BadRequestObjectResult(new MagitekApiResult() { Name = "Failure", Description = $"Wrong Password" });
            }

            using (var context = MagitekContextFactory.Create())
            {
                Console.WriteLine($"New News Message [{news.Title}]");

                news.Created = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);

                await context.AddAsync(news);
                await context.SaveChangesAsync();
            }

            return new ObjectResult(new MagitekApiResult() { Name = "Success", Description = $"Added News Message" });
        }
        #endregion
    }
}
