using System;
using System.Collections.Generic;
using System.Net.Http;
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
        
		public List<String> GetRandomJokes(string firstname, string lastname, string category, int number)
		{
			HttpClient client = new HttpClient();
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

            string joke = Task.FromResult(client.GetStringAsync(url).Result).Result;

            if (firstname != null && lastname != null)
            {
                int index = joke.IndexOf("Chuck Norris");
                string firstPart = joke.Substring(0, index);
                string secondPart = joke.Substring(0 + index + "Chuck Norris".Length, joke.Length - (index + "Chuck Norris".Length));
                joke = firstPart + " " + firstname + " " + lastname + secondPart;
            }

            return new List<String> { JsonConvert.DeserializeObject<dynamic>(joke).value };
        }
		
		public dynamic Getnames()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_endpoint);
			var result = client.GetStringAsync("").Result;
			return JsonConvert.DeserializeObject<dynamic>(result);
		}

		public List<String> GetCategories()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_endpoint);

			return new List<String> { Task.FromResult(client.GetStringAsync("categories").Result).Result };
		}
    }
}
