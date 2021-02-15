using System;
using System.Collections.Generic;
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
        private List<String> _categories;
        private Tuple<string, string> _names;
        
        public MyService(IMainService mainService, IOutput console)
        {
            _mainService = mainService;
            _console = console;
        }

        public async void Execute()
        {
            var currentStage = Stage.Start;
            while (true)
            {
                try
                {
                    switch (currentStage)
                    {
                        case Stage.Start:
                            _console.PrintNewLine(_mainService.GetStageContent(currentStage).Content);
                            if (CheckInputLine("?"))
                                currentStage = Stage.Options;
                            break;
                        case Stage.Options:
                            _console.PrintNewLine(_mainService.GetStageContent(currentStage).Content);
                            var input = GetInputKey();
                            if (input == 'c')
                            {
                                _categories = await _mainService.GetCategories();
                                _console.PrintResults(_categories);
                            }
                            else if (input == 'r')
                            {
                                currentStage = Stage.RandomName;
                            }
                            break;
                        case Stage.RandomName:
                            var category = string.Empty;
                            _console.PrintNewLine(_mainService.GetStageContent(currentStage).Content);
                            if (CheckInput('y'))
                            {
                                _names = await _mainService.GetNames();
                            }
                            _console.PrintNewLine(_mainService.GetStageContent(Stage.SpecifyCategory).Content);
                            if (CheckInput('y'))
                            {
                                _categories = await _mainService.GetCategories();
                                _console.PrintNewLine(_mainService.GetStageContent(Stage.EnterCategory).Content);
                                category = ReadLine();
                                if (!_categories.Contains(category))
                                    break;
                            }
                            _console.PrintNewLine(_mainService.GetStageContent(Stage.HowManyJokes).Content);
                            int n = 0;
                            var validNumber = Int32.TryParse(Console.ReadLine(), out n);
                            if (validNumber && n <= 9 && n >= 1)
                            {
                                var jokes = await _mainService.GetRandomJokes(category, n);
                                
                            }
                            
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    
                    Console.WriteLine("Invalid option, try again!");
                }
            }
        }

        private string ReadLine()
        {
            return Console.ReadLine();
        }
        
        private bool CheckInputLine(string key)
        {
            var input = Console.ReadLine();
            return input == key;
        }
        
        private bool CheckInput(char key)
        {
            var input = Console.ReadKey();
            return input.KeyChar == key;
        }

        private char GetInputKey()
        {
            var key = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return key;
        }
    }
}