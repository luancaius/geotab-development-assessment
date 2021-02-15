using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Provider;
using Service.Interfaces;

namespace Service
{
    public class MainService : IMainService
    {
        static Tuple<string, string> names;
        
        public StageContent GetStageContent(Stage stage)
        {
            var stageContent = new StageContent(stage);
            return stageContent;
        }
        
        public async Task<List<String>> GetRandomJokes(string category, int number)
        {
            var feed = new JsonFeed("https://api.chucknorris.io");
            return await feed.GetRandomJokes(names?.Item1, names?.Item2, category, number);
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
            names = Tuple.Create(result.name.ToString(), result.surname.ToString());
            return names;
        }
    }
}
