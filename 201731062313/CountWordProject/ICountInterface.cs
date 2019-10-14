using System;
using System.Collections.Generic;
using System.Text;

namespace CountWordProject
{
    interface ICountInterface
    {
        int CountChar(string content);
        int CountLine(string content);
        string[] CountWord(string content);
        Dictionary<string, int> WordRate(string[] word, int outNum);
        Dictionary<string, int> CountPhrases(string[] oldWord, int num1);
        void PrintNumber(string[] Word, int num2);
    }
}