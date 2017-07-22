using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MagitekApi.Database;
using MagitekApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagitekApi.Controllers
{
    [Route("/api/[controller]")]
    public class MagitekSettingsController : Controller
    {
        #region GET

        [HttpGet]
        public IActionResult GetAll()
        {
            List<MagitekSettings> magitekSettingsList;

            using (var context = MagitekContextFactory.Create())
            {
                magitekSettingsList = context.MagitekSettings.ToList();
            }

            return new OkObjectResult(magitekSettingsList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            MagitekSettings settings;

            using (var context = MagitekContextFactory.Create())
            {
                settings = await context.MagitekSettings.FirstOrDefaultAsync(r => r.Id == id);
            }

            if (settings == null)
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(settings);
        }

        [HttpGet]
        [Route("job/{job}")]
        public async Task<IActionResult> GetByJob(string job)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            List<MagitekSettings> magitekSettingsList;

            using (var context = MagitekContextFactory.Create())
            {
                magitekSettingsList = await context.MagitekSettings.Where(r => r.Job == job).ToListAsync();
            }

            stopWatch.Stop();
            Console.WriteLine($"Retrieved in {stopWatch.ElapsedMilliseconds} Milliseconds");

            return new OkObjectResult(magitekSettingsList);
        }

        [HttpGet]
        [Route("author/{author}")]
        public IActionResult GetByAuthor(string author)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            List<MagitekSettings> magitekSettingsList;

            using (var context = MagitekContextFactory.Create())
            {
                magitekSettingsList = context.MagitekSettings.Where(r => r.Author == author).ToList();
            }

            stopWatch.Stop();
            Console.WriteLine($"Retrieved in {stopWatch.ElapsedMilliseconds} Milliseconds");

            return new OkObjectResult(magitekSettingsList);
        }

        #endregion  

        #region POST

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] MagitekSettings settings)
        {
            using (var context = MagitekContextFactory.Create())
            {
                await context.AddAsync(settings);
                await context.SaveChangesAsync();
            }

            return Ok();
        }

        #endregion
    }
}
