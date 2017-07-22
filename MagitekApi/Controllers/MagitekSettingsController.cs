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
        public IQueryable<MagitekSettings> GetAllSettings()
        {
            return ControllerCon
        }

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
        [Route("{job}")]
        public IActionResult GetByJob(string job)
        {
            List<MagitekSettings> magitekSettingsList;

            using (var context = MagitekContextFactory.Create())
            {
                magitekSettingsList = context.MagitekSettings.Where(r => r.Job == job).ToList();
            }

            return new OkObjectResult(magitekSettingsList);
        }

        [HttpGet]
        [Route("{author}")]
        public async Task<IActionResult> GetByAuthor(string author)
        {
            MagitekSettings settings;

            using (var context = MagitekContextFactory.Create())
            {
                settings = await context.MagitekSettings.FirstOrDefaultAsync(r => string.Equals(r.Author, author, StringComparison.CurrentCultureIgnoreCase));
            }

            if (settings == null)
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(settings);
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
