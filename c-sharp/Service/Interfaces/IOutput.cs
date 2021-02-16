using System;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IOutput
    {
        void PrintNewLine(string result);
        void Print(string result);

        void PrintResults(List<String> results);
        
        void PrintResultsPerLine(List<String> results);
    }
}