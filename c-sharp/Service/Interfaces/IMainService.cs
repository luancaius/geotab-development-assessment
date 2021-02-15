using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMainService
    {
        StageContent GetStageContent(Stage stage);
        Task<List<String>> GetRandomJokes(string category, int number);
        Task<List<string>> GetCategories();
        Task<Tuple<string, string>> GetNames();
    }
}