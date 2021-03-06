﻿using System;
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
        // Discord webhook 
        private const string DiscordWebhook = "";
        private readonly HttpClient _client = new HttpClient();

        public BitBucketController(IDistributedCache redisCache) { }

        [HttpPost("")]
        public async Task<IActionResult> ReceiveMessage([FromBody] BitBucketMessage message)
        {
            Console.WriteLine($@"{message.actor.username} : {message.push.changes}");

            var newDiscordMessage = new DiscordMessage()
            {
                Content = $"```diff\n" +
                          $"New Commit To Bit Bucket\n" +
                          $"[Author]: {message.actor.username}\n" +
                          $"[Description]: {message.push.changes[0].commits[0].message}\n" +
                          $"```"
            };

            var json = JsonConvert.SerializeObject(newDiscordMessage);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync(DiscordWebhook, requestContent);

            return new OkResult();
        }
    }
}
