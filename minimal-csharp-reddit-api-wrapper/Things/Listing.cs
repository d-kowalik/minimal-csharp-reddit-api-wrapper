using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MinimalRedditWrapper.Things
{
    public class Listing<T> where T : Thing
    {
        public readonly string Url;
        public readonly string Name;
        private readonly Reddit _reddit;

        public string Kind;

        public ListingData<T> Data;

        public Listing(Reddit reddit, string name, string url, Newtonsoft.Json.Linq.JObject obj)
        {
            if (obj == null) throw new Exception("Cannot create Listing out of an empty object.");
            Url = url;
            Name = name;
            _reddit = reddit;
            Kind = (string)obj["kind"];
            Data = obj["data"]?.ToObject<ListingData<T>>();
        }

        public async Task<Listing<Post>> Next()
        {
            return await _reddit.GetSubreddit(Name, new Dictionary<string, string> {{"after", Data.After}});
        }

        public async Task<Listing<Post>> Previous()
        {
            return await _reddit.GetSubreddit(Name, new Dictionary<string, string> { { "before", Data.Before} });
        }
    }
}
