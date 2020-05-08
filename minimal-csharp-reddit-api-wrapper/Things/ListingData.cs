using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MinimalRedditWrapper.Things
{
    public class ListingData<T> where T : Thing
    {
        [JsonProperty("children")]
        public List<T> Children;

        [JsonProperty("before")]
        public string Before;

        [JsonProperty("after")]
        public string After;
    }
}
