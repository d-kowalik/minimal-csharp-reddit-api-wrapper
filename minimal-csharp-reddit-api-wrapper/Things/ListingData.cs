using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MinimalRedditWrapper.Things
{
    class ListingData<T>
    {
        [JsonProperty("children")]
        public List<T> Children;
    }
}
