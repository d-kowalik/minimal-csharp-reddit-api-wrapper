using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MinimalRedditWrapper.Things
{
    public class Listing<T> where T : Thing
    {
        public readonly string Url;
        private Reddit _reddit;

        [JsonProperty("kind")]
        public string Kind;

        [JsonProperty("data")]
        public ListingData<T> Data;

        public Listing(Reddit reddit, string url, Newtonsoft.Json.Linq.JObject obj)
        {
            if (obj == null) throw new Exception("Cannot create Listing out of an empty object.");
            Url = url;
            _reddit = reddit;
            Kind = (string)obj["kind"];
            Data = obj["data"]?.ToObject<ListingData<T>>();
        }
    }
}
