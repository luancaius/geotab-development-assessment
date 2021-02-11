using System;
using System.Collections.Generic;
using Provider;
using Service;
using Service.Interfaces;

namespace UIConsole
{
    public interface IMyService
    {
        void Execute();
    }

    public class MyService : IMyService
    {
        private IMainService _mainService;
        private IOutput _console;
        private List<String> _results;
        private Tuple<string, string> _names;
        
        public MyService(IMainService mainService, IOutput console)
        {
            _mainService = mainService;
            _console = console;
        }
        public void Execute()
        {
            _console.PrintNewLine(_mainService.GetStageContent(Stage.Start).Content);
            if (Console.ReadLine() == "?")
            {
                while (true)
                {
                    _console.PrintNewLine(_mainService.GetStageContent(Stage.Options).Content);
                    var key = Console.ReadKey();
                    if (key.KeyChar == 'c')
                    {
                        _results = _mainService.GetCategories();
                        _console.PrintResults(_results);
                    }
                    if (key.KeyChar == 'r')
                    {
                        _console.PrintNewLine(_mainService.GetStageContent(Stage.Random).Content);
                        key = Console.ReadKey();
                        if (key.KeyChar == 'y')
                            _names = _mainService.GetNames();
                        _console.PrintNewLine(_mainService.GetStageContent(Stage.SpecifyCategory).Content);
                        if (key.KeyChar == 'y')
                        {
                            _console.PrintNewLine(_mainService.GetStageContent(Stage.HowManyJokes).Content);
                            int n = Int32.Parse(Console.ReadLine());
                            _console.PrintNewLine("Enter a category;");
                            _results = _mainService.GetRandomJokes(Console.ReadLine(), n);
                            _console.PrintResults(_results);
                        }
                        else
                        {
                            _console.PrintNewLine(_mainService.GetStageContent(Stage.HowManyJokes).Content);
                            int n = Int32.Parse(Console.ReadLine());
                            _results = _mainService.GetRandomJokes(null, n);
                            _console.PrintResults(_results);
                        }
                    }
                    _names = null;
                }
            }
        }
    }
}