using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MinimalRedditWrapper
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string Value;

        [JsonProperty("expires_in")]
        public string ValidFor
        {
            set => ExpirationDate = DateTime.Now.AddSeconds(int.Parse(value));
        }

        public DateTime ExpirationDate { get; private set; }

        public static async Task<Token> Create(string appId)
        {
            var client = new HttpClient();

            var values = new Dictionary<string, string>
            {
                { "grant_type", "https://oauth.reddit.com/grants/installed_client" },
                { "device_id", "78dASHDASDS9989yd9ash(SDA(da" }
            };

            var byteArray = Encoding.ASCII.GetBytes(appId + ":");
            client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var content = new FormUrlEncodedContent(values);
            Console.WriteLine("Awaiting response...");

            var response = await client.PostAsync("https://www.reddit.com/api/v1/access_token", content);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Token>(responseString);
        }
    }
}
