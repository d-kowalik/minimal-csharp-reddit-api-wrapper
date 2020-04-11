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
        static async Task Main(string[] args)
        {
            var token = await Token.Create("g1b0mLRvuF7Sfg");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token.Value);
            client.DefaultRequestHeaders.Add("User-Agent", "reddit-api-tests by st_aeon");

            var response = await client.GetAsync("https://oauth.reddit.com/r/wallpapers/random");
            var responseString = await response.Content.ReadAsStringAsync();
            var listing = JsonConvert.DeserializeObject<Listing<Thing<PostData>>>(responseString);
            Console.WriteLine(responseString);
            Console.WriteLine(listing.After);
        }
    }
}
