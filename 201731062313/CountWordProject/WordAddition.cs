using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace CountWordProject
{
    class WordAddition : WordBasis
    {
        public Dictionary<string, int> DicCount(string[] PreviousWordlist, int num1)//DicCount()接受参数来组合词组、输出词组
        {
            string[] newWordlist = new string[PreviousWordlist.Length];
            int WordNum = 0;
            for (int i = 0; i < PreviousWordlist.Length - num1 + 1; i++)  //通过循环的嵌套产生并将旧词组存入新词组
            {
                for (int j = 0; j < num1; j++)
                {
                    newWordlist[i] += ' ' + PreviousWordlist[i + j];
                }
                WordNum++;
            }
            string[] lastWord = new string[WordNum];
            for (int i = 0; i < WordNum; i++)
            {
                lastWord[i] = newWordlist[i];
            }
            Console.WriteLine("词组个数：{0}", WordNum);
            string phrasesNum = "词组个数:" + WordNum;
            WriteFile(phrasesNum, CountWordProject.PrintPath);
            return WordRate(lastWord, WordNum);
        }
        public new void PrintNumber(string[] Word, int num2) //PrintNumber()用于按照参数输出n个高频词 
        {
            WordRate(Word, num2);
        }

    }

}