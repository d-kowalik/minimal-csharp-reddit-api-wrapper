using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MinimalRedditWrapper.Things
{
    public class PostData
    {
        [JsonProperty("thumbnail")] 
        public string Thumbnail;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("preview")] 
        public object Preview;
    }
}
