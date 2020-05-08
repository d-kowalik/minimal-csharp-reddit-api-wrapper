using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MinimalRedditWrapper.Things;

namespace MinimalRedditWrapper
{
    internal class Program
    {
        const string APP_ID = "g1b0mLRvuF7Sfg";
        private static async Task Main(string[] args)
        {
            var reddit = await Reddit.Create(APP_ID);
            var listing = await reddit.GetSubreddit("wallpapers");


            foreach (var child in listing.Data.Children)
            {
                Console.WriteLine(child.Data.Title);
                Console.WriteLine(child.Data.Url);
            }
        }
    }
}
