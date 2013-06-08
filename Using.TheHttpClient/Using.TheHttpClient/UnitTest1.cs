using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Using.TheHttpClient
{
    [TestClass]
    public class When_Using_The_HttpClient
    {
        [TestMethod]
        public async Task It_Should_Get()
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync("http://www.bing.com");
                Assert.IsNotNull(content);
                Console.WriteLine(content);
            }
        }

        [TestMethod]
        public async Task It_Should_Post()
        {
            var content = new FormUrlEncodedContent(
                new Dictionary<string,string>
                {
                    {"q","windows 8"}
                }
                );

            var uri = "http://www.bing.com/search";
            using (var client = new HttpClient())
            using (var response = await client.PostAsync(uri,content))
            {
                response.EnsureSuccessStatusCode();
                string s = await response.Content.ReadAsStringAsync();
                Console.WriteLine(s);
            }

        }

        [TestMethod]
        public async Task It_Should_Deserialize_The_Beers()
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(
                    "http://api.openbeerdatabase.com/v1/beers.json?token=98ee4043e471ad3207c54c1359db4a7dc8f518346cf0d120664ec5be9c24689b");
                var beerList = JsonConvert.DeserializeObject<BeerList>(content);
                Assert.IsTrue(beerList.beers.Count > 0);
                foreach (var beer in beerList.beers)
                {
                    Console.WriteLine(beer.name);
                    Console.WriteLine(beer.description);
                    Console.WriteLine(new String('-',80));
                }
            }
        }
    }
}
