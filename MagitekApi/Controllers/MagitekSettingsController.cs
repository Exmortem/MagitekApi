﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MagitekApi.Database;
using MagitekApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MagitekApi.Controllers
{
    [Route("/api/[controller]")]
    public class MagitekSettingsController : Controller
    {
        private const string DiscordWebhook = "https://discordapp.com/api/webhooks/338522123154751489/7fMEOnDCphVEuW10caQTVb5Fo6hTt-rMiAkdGr8vwwzikE5HushhFJO3QI-AM-8ifrCE";
        private HttpClient Client = new HttpClient();

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
                return new BadRequestObjectResult(new MagitekApiResult() { Name = "Failure", Description = $"No Settings Of Id: {id}" });
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
                return new ObjectResult(new List<MagitekSettings>());
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
                return new ObjectResult(new List<MagitekSettings>());
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
                return new ObjectResult(new List<MagitekSettings>());
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
                return new ObjectResult(new List<MagitekSettings>());
            }

            return new OkObjectResult(magitekSettingsList);
        }

        #endregion  

        #region POST
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] MagitekSettings settings)
        {
            using (var context = MagitekContextFactory.Create())
            {
                if (await context.MagitekSettings.AnyAsync(r => r.Job == settings.Job && r.Name == settings.Name))
                {
                    return new BadRequestObjectResult(new MagitekApiResult() { Name = "Failure", Description = "Failure: Duplicate Settings"});
                }

                Console.WriteLine($"New Settings [{settings.Job}] [{settings.Name}] From [{settings.Author}]");

                await context.AddAsync(settings);
                await context.SaveChangesAsync();
            }

            var newDiscordMessage = new DiscordMessage()
            {
                Content = $"```diff\n" +
                          $"New {settings.Job} Settings Were Uploaded\n" +
                          $"[Author]: {settings.Author}\n" +
                          $"[Name]: {settings.Name}\n" +
                          $"[Description]: {settings.Description}\n" +
                          $"``` "
            };

            var json = JsonConvert.SerializeObject(newDiscordMessage);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            await Client.PostAsync(DiscordWebhook, requestContent);

            return new ObjectResult(new MagitekApiResult() { Name = "Success", Description = $"Success: Added New {settings.Job} Settings"});
        }
        #endregion
    }
}
