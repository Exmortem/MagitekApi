using Newtonsoft.Json;

namespace MagitekApi.Models
{
    public class BitBucketMessage
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("repo")]
        public string Repo { get; set; }

        [JsonProperty("commit")]
        public string Commit { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
