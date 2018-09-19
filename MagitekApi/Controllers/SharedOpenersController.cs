using System;
using System.Collections.Generic;
using System.Globalization;
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
    [Route("[controller]")]
    public class SharedOpenersController
    {
        private const string DiscordWebhook = "https://discordapp.com/api/webhooks/338522123154751489/7fMEOnDCphVEuW10caQTVb5Fo6hTt-rMiAkdGr8vwwzikE5HushhFJO3QI-AM-8ifrCE";
        private readonly HttpClient _client = new HttpClient();

        #region Get

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<SharedOpener> sharedOpenersList;

            using (var context = MagitekContextFactory.Create())
            {
                sharedOpenersList = await context.SharedOpeners.ToListAsync();
            }

            return new OkObjectResult(sharedOpenersList);
        }

        [HttpGet]
        [Route("job/{job}")]
        public async Task<IActionResult> GetByJob(string job)
        {
            List<SharedOpener> sharedOpenersList;

            using (var context = MagitekContextFactory.Create())
            {
                sharedOpenersList = await context.SharedOpeners.Where(r => r.Job == job).ToListAsync();
            }

            if (!sharedOpenersList.Any())
            {
                return new ObjectResult(new List<MagitekSettings>());
            }

            return new OkObjectResult(sharedOpenersList);
        }

        [HttpGet]
        [Route("remove/{gambitId}/{posterId}")]
        public async Task<IActionResult> RemoveByPosterId(int gambitId, string posterId)
        {
            SharedOpener sharedOpener;

            using (var context = MagitekContextFactory.Create())
            {
                sharedOpener = await context.SharedOpeners.FirstOrDefaultAsync(r => r.Id == gambitId && r.PosterId == posterId);

                if (sharedOpener == null)
                    return new ObjectResult(new MagitekApiResult { Name = "Failure", Description = "Failure: Gambit Cannot Be Found" });

                context.SharedOpeners.Remove(sharedOpener);
                await context.SaveChangesAsync();

                return new OkObjectResult(new MagitekApiResult { Name = "Success", Description = $"Success: Removed Gambit Id: {sharedOpener.Id} - Name: {sharedOpener.Name}" });
            }
        }

        #endregion

        #region POST

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] SharedOpener sharedOpener)
        {
            using (var context = MagitekContextFactory.Create())
            {
                if (await context.SharedGambits.AnyAsync(r => r.Id == sharedOpener.Id))
                {
                    return new BadRequestObjectResult(new MagitekApiResult() { Name = "Failure", Description = "Failure: Duplicate Gambit Id" });
                }

                Console.WriteLine($"New Shared Opener for [{sharedOpener.Job}] : [{sharedOpener.Name}]");
                sharedOpener.Created = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);

                await context.AddAsync(sharedOpener);
                await context.SaveChangesAsync();
            }

            var newDiscordMessage = new DiscordMessage()
            {
                Content = $"```diff\n" +
                          $"+ New {sharedOpener.Job} Opener Was Uploaded\n" +
                          $"[Name]: {sharedOpener.Name}\n" +
                          $"[Job]: {sharedOpener.Job}\n" +
                          $"[Description]: {sharedOpener.Description}\n" +
                          $"```"
            };

            var json = JsonConvert.SerializeObject(newDiscordMessage);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync(DiscordWebhook, requestContent);

            return new ObjectResult(new MagitekApiResult() { Name = "Success", Description = $"Success: Added New {sharedOpener.Job} Shared Gambit(s)" });
        }

        #endregion
    }
}
