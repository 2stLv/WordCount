using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace CountWordProject
{
    public class WordBasis : ICountInterface
    {
        public int CountChar(string CountString)//CountChar函数接收一个字符串参数，用于计算文档的字符数
        {
            int CharNumber = CountString.Length;
            Console.WriteLine("字符数：" + CharNumber);
            WriteFile("字符数：" + CharNumber, CountWordProject.PrintPath);
            return CharNumber;
        }
        public int CountLine(string CountString)//CountLine函数接受一个字符串参数，用于计算文档的行数
        {
            string Replace = Regex.Replace(CountString, @"\n\s*\n", "\r\n");
            int LineNumber = Replace.Split('\n').Length;
            Console.WriteLine("行数：" + LineNumber);
            WriteFile("行数：" + LineNumber, CountWordProject.PrintPath);
            return LineNumber;
        }
        public string[] CountWord(string CountString) //CountWord接收一个字符串参数，返回一个string数组，用于计算文档中符合约束的单词数
        {
            int CountNumber = 0;
            string LowCountString = CountString.ToLower();
            string[] WordList = Regex.Split(LowCountString, @"\W+");
            string[] DoneWord = new string[WordList.Length];
            for (int i = 0; i < WordList.Length; i++)
            {
                if (Regex.IsMatch(WordList[i], @"^[a-z][a-z][a-z][a-z]"))
                {
                    DoneWord[CountNumber] = WordList[i];
                    CountNumber++;
                }
            }
            string[] MyWord = new string[CountNumber];
            for (int i = 0; i < CountNumber; i++)
            {
                MyWord[i] = DoneWord[i];
            }
            Console.WriteLine("单词数：" + CountNumber);
            WriteFile("单词数：" + CountNumber, CountWordProject.PrintPath);
            return MyWord;
        }
        public Dictionary<string, int> WordRate(string[] CountWord, int OutNum) //CountWord接收一个单词字符串数组和一个频率整型参数，用于计算文档中符合约束的单词以及其出现频率并排序
        {
            int CountNum = 0;
            Dictionary<string, int> DicWordRate = new Dictionary<string, int>();
            for (int i = 0; i < CountWord.Length; i++)
            {
                if (!DicWordRate.ContainsKey(CountWord[i]))
                {
                    DicWordRate[CountWord[i]] = 1;
                }
                else
                {
                    DicWordRate[CountWord[i]]++;
                }
            }
            var CountResult = DicWordRate.OrderByDescending(o => o.Value).ThenBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            foreach (KeyValuePair<string, int> MyPair in CountResult)
            {
                Console.WriteLine(MyPair.Key + ":" + MyPair.Value);
                WriteFile(MyPair.Key + ":" + MyPair.Value, CountWordProject.PrintPath);
                CountNum++;
                if (CountNum == OutNum)
                {
                    break;
                }
            }
            return CountResult;
        }
        public void FinalCount(string CountString) //FinalCount函数接收一个字符串参数，调用上述所有函数处理文档
        {
            string[] word;
            CountChar(CountString);
            CountLine(CountString);
            word = CountWord(CountString);
            WordRate(word, 10);
        }
        public bool ReadFile(string Mypath) //Read File函数获取文档路径、读取文档内容
        {
            bool MyTest0 = false;
            try
            {
                if (File.Exists(Mypath))
                {
                    MyTest0 = true;
                    string CountString;
                    CountString = File.ReadAllText(Mypath);
                    Console.WriteLine("文档读取成功");
                    FinalCount(CountString);
                }
            }
            catch
            {
                Console.WriteLine("文档读取失败");
            }
            return MyTest0;
        }
        public bool WriteFile(string CountString, string PrintPath)//WriteFile函数写入文档内容
        {
            bool test = false;
            try
            {
                if (CountString != null)
                {
                    test = true;
                    using (StreamWriter sw = new StreamWriter(PrintPath, true))
                    {
                        sw.WriteLine(CountString);
                    }
                }
            }
            catch
            {
              //  Console.WriteLine("文档写入失败");
            }
            return test;
        }
        public Dictionary<string, int> CountPhrases(string[] oldWord, int num1)
        {
            throw new NotImplementedException();
        }
        public void PrintNumber(string[] Word, int num2)
        {
            throw new NotImplementedException();
        }
    }
}