using System;
using System.Collections.Generic;
using Service.Interfaces;

namespace Service.Util
{
    public class ConsolePrinter : IOutput
    {
        public void PrintNewLine(string result)
        {
            Console.WriteLine(result);
        }

        public void Print(string result)
        {
            Console.Write(result);
        }

        public void PrintResults(List<string> results)
        {
            Console.WriteLine($"\n[{string.Join(",", results)}]");
        }
    }
}