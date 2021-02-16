using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Provider
{
    public class JsonFeed
    {
        public string _endpoint;

        public JsonFeed(string endpoint)
        {
            _endpoint = endpoint;
        }

        public async Task<String> GetRandomJokes(string firstname, string lastname, string category)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_endpoint);
            string url = "jokes/random";
            if (!String.IsNullOrEmpty(category))
            {
                if (url.Contains('?'))
                    url += "&";
                else url += "?";
                url += "category=";
                url += category;
            }

            dynamic response = await Task.FromResult(client.GetStringAsync(url).Result);

            string joke = JsonConvert.DeserializeObject<dynamic>(response).value;
            
            if (firstname != null && lastname != null)
            {
                int index = joke.IndexOf("Chuck Norris");
                string firstPart = joke.Substring(0, index);
                string secondPart = joke.Substring(0 + index + "Chuck Norris".Length,
                    joke.Length - (index + "Chuck Norris".Length));
                joke = firstPart + " " + firstname + " " + lastname + secondPart;
            }

            return joke;
        }

        public async Task<dynamic> Getnames()
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(_endpoint);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = client.GetAsync("").Result;

                return JsonConvert.DeserializeObject<dynamic>(await result.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<String>> GetCategories()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(_endpoint);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = client.GetAsync("categories").Result;

            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<String>>(content);
        }
    }
}

