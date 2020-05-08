using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MinimalRedditWrapper.Things
{
    public class Reddit
    {
        private Token _token;
        private HttpClient _client;
        public string RequestUrl => "https://oauth.reddit.com/";
        public string SubredditRequestUrl => RequestUrl + "r/";
        public static async Task<Reddit>  Create(string appId)
        {
            Reddit res = new Reddit
            {
                _token =  await Token.Create(appId),
                _client = new HttpClient()
            };

            res._client.DefaultRequestHeaders.Add("Authorization", "bearer " + res._token.Value);
            res._client.DefaultRequestHeaders.Add("User-Agent", "reddit-api-tests by st_aeon");

            return res;
        }

        public async Task<Listing<Post>> GetSubreddit(string name)
        {
            var response = await _client.GetAsync(SubredditRequestUrl + "wallpapers");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Listing<Post>>(responseString);
        }
    }
}
