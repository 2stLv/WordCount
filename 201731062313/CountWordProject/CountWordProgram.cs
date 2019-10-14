using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace CountWordProject
{
    public class CountWordProject
    {
        static int MyNum1, MyNum = 0;
        static string PathIn, PathOut;
        public static string PrintPath { get => PathOut; set => PathOut = value; }
        public static void Main(string[] args)
        {
            if (args.Length > 0)// 使用命令行
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-i")
                        PathIn = args[++i];
                    else if (args[i] == "-o")
                        PrintPath = args[++i];
                    else if (args[i] == "-m")
                        MyNum1 = Convert.ToInt32(args[++i]);
                    else if (args[i] == "-n")
                        MyNum = Convert.ToInt32(args[++i]);
                }
                if (PathIn != null && PrintPath != null)
                {
                    string MyContent = null;//保存从文档中读取的内容      
                    MyContent = File.ReadAllText(PathIn);  //读取路径文档中的内容
                    WordAddition addFunction = new WordAddition();
                    addFunction.CountChar(MyContent);
                    string[] Word = addFunction.CountWord(MyContent);
                    addFunction.CountLine(MyContent);
                    if (MyNum1 > 0 && MyNum == 0) //命令行参数情况
                    {
                        addFunction.DicCount(Word, MyNum1);
                    }
                    else if (MyNum > 0 && MyNum1 == 0)
                    {
                        addFunction.PrintNumber(Word, MyNum);
                    }
                    else if (MyNum1 > 0 && MyNum > 0)
                    {
                        addFunction.PrintNumber(Word, MyNum);
                        addFunction.DicCount(Word, MyNum1);
                    }
                }
                else
                    Console.WriteLine("路径错误，失败！");
            }
            else//不使用命令行
            {
                WordBasis basisFunction = new WordBasis();
                Console.WriteLine("读取文档路径：");
                string path = Console.ReadLine();
                basisFunction.ReadFile(path);
                Console.Read();
            }
        }
    }
}