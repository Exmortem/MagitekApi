using System;
using System.Collections.Generic;
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
            List<MagitekSettings> magitekSettingsList;

            using (var context = MagitekContextFactory.Create())
            {
                magitekSettingsList = await context.MagitekSettings.Where(r => r.Job == job).ToListAsync();
            }

            if (!magitekSettingsList.Any())
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(magitekSettingsList);
        }

        [HttpGet]
        [Route("job/{job}/{rating}")]
        public async Task<IActionResult> GetByJobAndRating(string job, int rating)
        {
            List<MagitekSettings> magitekSettingsList;

            using (var context = MagitekContextFactory.Create())
            {
                magitekSettingsList = await context.MagitekSettings.Where(r => r.Job == job && r.Rating >= rating).ToListAsync();
            }

            if (!magitekSettingsList.Any())
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(magitekSettingsList);
        }

        [HttpGet]
        [Route("author/{author}")]
        public async Task<IActionResult> GetByAuthor(string author)
        {
            List<MagitekSettings> magitekSettingsList;

            using (var context = MagitekContextFactory.Create())
            {
                magitekSettingsList = await context.MagitekSettings.Where(r => r.Author == author).ToListAsync();
            }

            if (!magitekSettingsList.Any())
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(magitekSettingsList);
        }

        [HttpGet]
        [Route("author/{author}/{rating}")]
        public async Task<IActionResult> GetByAuthorAndRating(string author, int rating)
        {
            List<MagitekSettings> magitekSettingsList;

            using (var context = MagitekContextFactory.Create())
            {
                magitekSettingsList = await context.MagitekSettings.Where(r => r.Author == author && r.Rating >= rating).ToListAsync();
            }

            if (!magitekSettingsList.Any())
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(magitekSettingsList);
        }

        #endregion  

        #region POST

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] MagitekSettings settings)
        {
            Console.WriteLine($"New Settings [{settings.Job}] [{settings.Name}] From [{settings.Author}]");

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
