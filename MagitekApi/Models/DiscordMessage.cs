using Newtonsoft.Json;

namespace MagitekApi.Models
{
    public class DiscordMessage
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
