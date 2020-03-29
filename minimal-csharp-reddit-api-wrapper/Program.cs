﻿using System;
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
    class Program
    {

        static async Task Main(string[] args)
        {
            var token = await Token.Create("g1b0mLRvuF7Sfg");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token.Value);
            client.DefaultRequestHeaders.Add("User-Agent", "reddit-api-tests by st_aeon");

            var response = await client.GetAsync("https://oauth.reddit.com/r/wallpapers/random");
            var responseString = await response.Content.ReadAsStringAsync();
            var listing = JsonConvert.DeserializeObject<Listing<Thing<PostData>>>(responseString);
            //Console.WriteLine(responseString);
            foreach (var child in listing.data.children)
            {
                Console.WriteLine(child.data.thumbnail);
            }
        }
    }
}