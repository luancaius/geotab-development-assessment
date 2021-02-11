using System;
using System.Collections.Generic;
using Provider;
using Service.Interfaces;

namespace Service
{
    public class MainService : IMainService
    {
        static char key;
        static Tuple<string, string> names;
        
        public StageContent GetStageContent(Stage stage)
        {
            var stageContent = new StageContent(stage);
            return stageContent;
        }
        
        public List<String> GetRandomJokes(string category, int number)
        {
            var feed = new JsonFeed("https://api.chucknorris.io");
            return feed.GetRandomJokes(names?.Item1, names?.Item2, category, number);
        }

        public List<String> GetCategories()
        {
            var feed = new JsonFeed("https://api.chucknorris.io/jokes/categories");
            return feed.GetCategories();
        }

        public Tuple<string, string> GetNames()
        {
            var feed = new JsonFeed("https://www.names.privserv.com/api/");
            dynamic result = feed.Getnames();
            names = Tuple.Create(result.name.ToString(), result.surname.ToString());
            return names;
        }
    }
}
