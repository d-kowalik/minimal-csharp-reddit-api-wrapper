using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MinimalRedditWrapper.Things
{
    public class Listing<T>
    {
        [JsonProperty("kind")]
        public string Kind;
        [JsonProperty("before")]
        string Before;
        [JsonProperty("after")]
        public string After;
        [JsonProperty("data")]
        public ListingData<T> Data;
    }
}
