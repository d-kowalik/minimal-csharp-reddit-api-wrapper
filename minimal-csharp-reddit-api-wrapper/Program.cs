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
        private static async Task Main(string[] args)
        {
            var token = await Token.Create("g1b0mLRvuF7Sfg");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token.Value);
            client.DefaultRequestHeaders.Add("User-Agent", "reddit-api-tests by st_aeon");

            var response = await client.GetAsync("https://oauth.reddit.com/r/wallpapers/.json");
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject(responseString);
            Console.WriteLine(responseObject);
            var listing = JsonConvert.DeserializeObject<Listing<Post>>(responseString);

            Console.WriteLine("AFTER: {0}", listing.Data.After);
            var afterResponse = await client.GetAsync("https://oauth.reddit.com/r/wallpapers?after="+listing.Data.After);
            var afterResponseString = await afterResponse.Content.ReadAsStringAsync();
            var afterResponseObject = JsonConvert.DeserializeObject(afterResponseString);
            // Console.WriteLine(afterResponseObject);
            var afterListing = JsonConvert.DeserializeObject<Listing<Post>>(afterResponseString);


            foreach (var child in afterListing.Data.Children)
            {
                Console.WriteLine(child.Data.Title);
                Console.WriteLine(child.Data.Url);
            }
        }
    }
}
