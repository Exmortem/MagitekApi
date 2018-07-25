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
    public class SharedGambitsController : Controller
    {
        private const string DiscordWebhook = "https://discordapp.com/api/webhooks/338522123154751489/7fMEOnDCphVEuW10caQTVb5Fo6hTt-rMiAkdGr8vwwzikE5HushhFJO3QI-AM-8ifrCE";
        private readonly HttpClient _client = new HttpClient();

        #region Get

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<SharedGambit> sharedGambitsList;

            using (var context = MagitekContextFactory.Create())
            {
                sharedGambitsList = await context.SharedGambits.ToListAsync();
            }

            return new OkObjectResult(sharedGambitsList);
        }

        [HttpGet]
        [Route("job/{job}")]
        public async Task<IActionResult> GetByJob(string job)
        {
            List<SharedGambit> sharedGambitsList;

            using (var context = MagitekContextFactory.Create())
            {
                sharedGambitsList = await context.SharedGambits.Where(r => r.Job == job).ToListAsync();
            }

            if (!sharedGambitsList.Any())
            {
                return new ObjectResult(new List<MagitekSettings>());
            }

            return new OkObjectResult(sharedGambitsList);
        }

        #endregion

        #region POST

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] SharedGambit sharedGambit)
        {
            using (var context = MagitekContextFactory.Create())
            {
                if (await context.SharedGambits.AnyAsync(r => r.Id == sharedGambit.Id))
                {
                    return new BadRequestObjectResult(new MagitekApiResult() { Name = "Failure", Description = "Failure: Duplicate Gambit Id" });
                }

                Console.WriteLine($"New Shared Gambits for the [{sharedGambit.Job}] : [{sharedGambit.Name}] From [{sharedGambit.Author}]");
                sharedGambit.Created = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);

                await context.AddAsync(sharedGambit);
                await context.SaveChangesAsync();
            }

            var newDiscordMessage = new DiscordMessage()
            {
                Content = $"```diff\n" +
                          $"New {sharedGambit.Job} Gambit(s) Were Uploaded\n" +
                          $"[Author]: {sharedGambit.Author}\n" +
                          $"[Name]: {sharedGambit.Name}\n" +
                          $"[Description]: {sharedGambit.Description}\n" +
                          $"```"
            };

            var json = JsonConvert.SerializeObject(newDiscordMessage);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync(DiscordWebhook, requestContent);

            return new ObjectResult(new MagitekApiResult() { Name = "Success", Description = $"Success: Added New {sharedGambit.Job} Shared Gambit(s)" });
        }

        #endregion
    }
}
