using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
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

            var listing2 = await listing.Next();

            var listing3 = await listing2.Previous();

            Console.WriteLine(listing.Data.Children[0].Data.Thumbnail == listing3.Data.Children[0].Data.Thumbnail);
        }
    }
}
