﻿using Newtonsoft.Json;

namespace dotMCLauncher.Versioning
{
    public class Rule
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("os")]
        public Os Os { get; set; }

        [JsonProperty("features")]
        public Features Features { get; set; }
    }
}
