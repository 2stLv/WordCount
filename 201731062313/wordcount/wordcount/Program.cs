using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordcount
{
    class Program
    {
        //int n;
        public class Global
        {
            public static int n;
            public static int[] count;
        }


        static int CountLine(char[] a)//计算行数
        {
            int line = 1;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 13 && a[i + 1] == 10)//在Windows中，另起一行是换行加回车
                    line++;
            }
            return line;
        }


        static string[] CountWord(char[] c)
        {
            int x;
            x = c.Length / 4;
            string[] d = new string[x];
            for (int i = 0; i < d.Length; i++)// shabiwanglei
            {
                d[i] = null;
            }
            Global.n = 0;//
            for (int i = 0; i < c.Length;)
            {
                int j = i;
                while (i < c.Length)
                {
                    if ((c[i] >= 'A' && c[i] <= 'Z') || (c[i] >= 'a' && c[i] <= 'z'))//看开头是不是字母
                    {
                        for (; i < c.Length; i++)
                        {
                            if ((c[i] >= 'A' && c[i] <= 'Z') || (c[i] >= 'a' && c[i] <= 'z') || (c[i] >= '0' && c[i] <= '9'))//看字符是不是字母或数字
                            {

                                if (c[i] >= 'A' && c[i] <= 'Z')//看字母是不是大写字母，如果是，那么变为小写
                                    c[i] = char.ToLower(c[i]);//变小写
                            }
                            else break;
                        }
                    }
                    else break;
                }
                i++;
                if (i - j > 4)
                {

                    for (int k = 0; k < i - j - 1; k++)
                    {
                        d[Global.n] = d[Global.n] + c[j + k];//存单词
                    }
                    Global.n++;
                }
            }
            return d;
        }//计算单词个数


        static string[] CountWordTime(string[] d)
        {
            Array.Sort(d);
            while (d[0] == null)
            {
                for (int j = 0; j < d.Length - 1; j++)
                {
                    d[j] = d[j + 1];
                }
            }
            Global.count = new int[d.Length];
            for (int i = 0; i < Global.n; i++)
            {
                Global.count[i] = 1;
            }
            for (int i = 0; i < Global.n; i++)
            {
                int k = i;
                while (d[k] == d[k + 1])
                {
                    Global.count[i]++;
                    //count[i]++;
                    for (int j = i; j < Global.n - 1; j++)
                    {
                        d[j] = d[j + 1];
                    }
                    d[Global.n - 1] = null;
                    Global.n--;
                }
            }
            int temp;
            string Stemp;
            for (int i = 0; i < Global.n; i++)
            {
                for (int j = i + 1; j < Global.n; j++)
                {
                    if (Global.count[j] > Global.count[i])
                    {
                        temp = Global.count[i];
                        Global.count[i] = Global.count[j];
                        Global.count[j] = temp;
                        Stemp = d[i];
                        d[i] = d[j];
                        d[j] = Stemp;
                    }
                }
            }
            return d;
        }//计算词频并按从多到少排列


        static void WordLength(string[] d, int n)//按照指定长度输出单词及其频率
        {
            for (int i = 0; i < Global.n; i++)
            {
                if (d[i].Length == n)
                {
                    Console.WriteLine(Global.count[i]);
                    Console.WriteLine(d[i]);
                }
            }
        }
        static void PrintTime(string[] d, int n)
        {
            for (int i = 0; i < Global.n; i++)
            {
                Console.Write(d[i] + ":");
                Console.WriteLine(Global.count[i]);
            }
        }
        static string InputPath;//读取文件路径
        static int Wordlength;//需要统计的单词长度
        static int WordCount;//输出的单词的数量  默认为10
        static string OutputPath;//输出文件路径
        static void Main(string[] args)
        {
            //string text = System.IO.File.ReadAllText(@"D:/test.txt");//读取txt文件
            //Console.WriteLine(text);
            //char[] c = text.ToCharArray();
            //string[] d = CountWord(c);
            //d = CountWordTime(d);
            //Console.WriteLine("characters:"+c.Length);
            //Console.WriteLine("words:"+Global.n);
            //Console.WriteLine("lines:"+CountLine(c));


            if (args.Length > 0)
            {
                //对命令行参数进行判断（-m、-n、-i、-o）并保存参数
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-i")
                        InputPath = args[++i];
                    else if (args[i] == "-m")
                        Wordlength = Convert.ToInt32(args[++i]);
                    else if (args[i] == "-o")
                        OutputPath = args[++i];
                    else if (args[i] == "-n")
                        WordCount = Convert.ToInt32(args[++i]);
                }



                if (InputPath != null && OutputPath != null)
                {

                    //定义字符串，用于保存从文件中读取的内容
                    string text = null;

                    //读取参数-i的路径文件中的内容
                    //System.IO.File.ReadAllText(@"D:/test.txt");
                    text = System.IO.File.ReadAllText(InputPath);
                    char[] c = text.ToCharArray();

                    string[] d = CountWord(c);//将单词进行整理

                    //实例化附加功能类，父类功能可以直接调用
                    //AdditionalFunction addFunction = new AdditionalFunction();
                    //addFunction.CountChar(content);
                    //string[] Word = addFunction.CountWord(content);
                    //addFunction.CountLine(content);

                    //三种情况：有-m没-n  有-n没-m  -n，-m都有
                    if (Wordlength > 0 && WordCount == 0)//有输入统计单词长度，无输入要求统计前几频率
                    {
                        Console.WriteLine("characters:" + c.Length);
                        Console.WriteLine("words:" + Global.n);
                        Console.WriteLine("lines:" + CountLine(c));
                        WordLength(d, Wordlength);
                        //addFunction.countPhrases(Word, num1);

                    }
                    else if (WordCount > 0 && Wordlength == 0)//无输入统计单词长度，有输入要求统计前几频率
                    {
                        Console.WriteLine("characters:" + c.Length);
                        Console.WriteLine("words:" + Global.n);
                        Console.WriteLine("lines:" + CountLine(c));
                        for (int i = 0; i < WordCount; i++)
                        {
                            Console.Write(d[i] + ":");
                            Console.WriteLine(Global.count[i]);
                        }
                        //addFunction.outputNum(Word, num2);

                    }
                    else if (WordCount > 0 && Wordlength > 0)//有输入统计单词长度，有输入要求统计前几频率
                    {
                        Console.WriteLine("characters:" + c.Length);
                        Console.WriteLine("words:" + Global.n);
                        Console.WriteLine("lines:" + CountLine(c));
                        WordLength(d, Wordlength);
                        for (int i = 0; i < WordCount; i++)
                        {
                            Console.Write(d[i] + ":");
                            Console.WriteLine(Global.count[i]);
                        }

                    }
                }

                else
                    Console.WriteLine("路径不正确，读取文档失败！");

            }

            //无命令行参数
            /*else
            {
                //BasisFunction basisFunction = new BasisFunction();
                Console.WriteLine("请输入需要读取的文档的路径：");
                string path = Console.ReadLine();

                //basisFunction.ReadFile(path);

            }*/
            /*for (int i = 0; i < Global.n; i++)
            {
                Console.Write(d[i]+":");
                Console.WriteLine(Global.count[i]);  
            }*/
            Console.ReadKey();
        }
    }
}

