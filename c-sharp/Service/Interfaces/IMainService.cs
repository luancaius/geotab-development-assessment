using System;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IMainService
    {
        StageContent GetStageContent(Stage stage);
        List<String> GetRandomJokes(string category, int number);
        List<String> GetCategories();
        Tuple<string, string> GetNames();
    }
}