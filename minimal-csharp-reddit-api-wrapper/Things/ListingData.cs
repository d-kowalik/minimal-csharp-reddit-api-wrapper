using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MinimalRedditWrapper.Things
{
    public class ListingData<T>
    {
        [JsonProperty("children")]
        public List<T> Children;
    }
}
