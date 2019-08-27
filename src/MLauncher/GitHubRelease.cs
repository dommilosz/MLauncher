using Newtonsoft.Json;

namespace MLauncher
{
    public class GitHubRelease
    {
        [JsonProperty("tag_name")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("published_at")]
        public string ReleaseTime { get; set; }

        [JsonProperty("body")]
        public string Description { get; set; }
    }
}
