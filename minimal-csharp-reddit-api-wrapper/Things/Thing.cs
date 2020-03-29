using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace MinimalRedditWrapper.Things
{
    class Thing<T>
    {
        [JsonProperty("data")]
        public T Data;
    }
}
