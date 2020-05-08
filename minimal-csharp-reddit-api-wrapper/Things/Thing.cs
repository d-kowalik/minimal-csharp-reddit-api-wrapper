using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace MinimalRedditWrapper.Things
{
    public class Thing
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;
        
        [JsonProperty("kind")]
        public string Kind;

        [JsonProperty("data")]
        public Newtonsoft.Json.Linq.JObject Data;
    }
}
