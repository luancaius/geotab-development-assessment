using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Provider;
using Service.Interfaces;

namespace Service
{
    public class MainService : IMainService
    {
        public StageContent GetStageContent(Stage stage)
        {
            var stageContent = new StageContent(stage);
            return stageContent;
        }
        
        public async Task<List<string>> GetRandomJokes(string category, int number, Tuple<string, string> names)
        {
            var feed = new JsonFeed("https://api.chucknorris.io");
            var jokes = new List<String>();
            for (var i = 0; i < number; i++)
            {
                var result = await feed.GetRandomJokes(names?.Item1, names?.Item2, category);
                jokes.Add(result);
            }
            return jokes;
        }

        public async Task<List<String>> GetCategories()
        {
            var feed = new JsonFeed("https://api.chucknorris.io/jokes/categories");
            return await feed.GetCategories();
        }

        public async Task<Tuple<string, string>> GetNames()
        {
            var feed = new JsonFeed("https://www.names.privserv.com/api/");
            dynamic result = await feed.Getnames();
            var names = Tuple.Create(result.name.ToString(), result.surname.ToString());
            return names;
        }
    }
}
