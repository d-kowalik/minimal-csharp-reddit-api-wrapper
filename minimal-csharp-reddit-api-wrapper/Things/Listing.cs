using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MinimalRedditWrapper.Things
{
    public class Listing<T> where T : Thing
    {
        [JsonProperty("kind")]
        public string Kind;

        [JsonProperty("data")]
        public ListingData<T> Data;
    }
}
