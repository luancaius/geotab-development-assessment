using System;
using System.Collections.Generic;
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
        
		public async Task<List<String>> GetRandomJokes(string firstname, string lastname, string category, int number)
		{
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(_endpoint);
				string url = "jokes/random";
				if (category != null)
				{
					if (url.Contains('?'))
						url += "&";
					else url += "?";
					url += "category=";
					url += category;
				}

				string joke = await Task.FromResult(client.GetStringAsync(url).Result);

				if (firstname != null && lastname != null)
				{
					int index = joke.IndexOf("Chuck Norris");
					string firstPart = joke.Substring(0, index);
					string secondPart = joke.Substring(0 + index + "Chuck Norris".Length,
						joke.Length - (index + "Chuck Norris".Length));
					joke = firstPart + " " + firstname + " " + lastname + secondPart;
				}

				return new List<String> {JsonConvert.DeserializeObject<dynamic>(joke).value};
			}
		}
		
		public async Task<dynamic> Getnames()
		{
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(_endpoint);
				var result = await client.GetStringAsync("");
				return JsonConvert.DeserializeObject<dynamic>(result);
			}
		}

		public async Task<List<String>> GetCategories()
		{
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(_endpoint);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var result = client.GetAsync("categories");

				var content = await result.Result.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<String>>(content);
			}
		}
    }
}
