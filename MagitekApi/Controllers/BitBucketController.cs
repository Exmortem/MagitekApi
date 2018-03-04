using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MagitekApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace MagitekApi.Controllers
{
    [Route("[controller]")]
    public class BitBucketController : Controller
    {
        private const string DiscordWebhook = "https://discordapp.com/api/webhooks/409798949113954304/QS2UdRnwqmV8Gf3HJbqh3UudF8pMw9BnMzANSoRcj6huMZHtaLbeGDPIexITelEpFT2G";
        private readonly HttpClient _client = new HttpClient();

        public BitBucketController(IDistributedCache redisCache)
        {

        }

        [HttpPost("")]
        public async Task<IActionResult> ReceiveMessage([FromBody] BitBucketMessage message)
        {
            Console.WriteLine($@"{message.actor.username} : {message.push.changes}");

            var newDiscordMessage = new DiscordMessage()
            {
                Content = $@"{message.actor.display_name} : {message.push.changes[0]}"
            };

            var json = JsonConvert.SerializeObject(newDiscordMessage);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync(DiscordWebhook, requestContent);

            return new OkResult();
        }
    }
}
