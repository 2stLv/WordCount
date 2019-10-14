using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordcount
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
                string text = System.IO.File.ReadAllText(@"D:/test.txt");//读取txt文件
                Console.WriteLine(text);
                char[] c = text.ToCharArray();
                int x;
                x = c.Length / 4;
                string[] d = new string[x];
                for (int i = 0; i < d.Length; i++)// shabiwanglei
                {
                    d[i] = null;
                }
                int n = 0;//
                int hang = 1;
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == 13 && c[i + 1] == 10)
                        hang++;
                }
                Console.WriteLine("yigongyouduoshaohang:" + hang);
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
                            d[n] = d[n] + c[j + k];//存单词
                        }
                        n++;
                    }
                }
                Console.WriteLine("排序前打印：");
                for (int i = 0; i < d.Length; i++)
                {
                    if (d[i] != null)
                        Console.WriteLine(d[i]);
                }

                Array.Sort(d);
                Console.WriteLine(n);
                while (d[0] == null)
                {
                    for (int j = 0; j < d.Length - 1; j++)
                    {
                        d[j] = d[j + 1];
                    }
                }
                Console.WriteLine("排序后打印：");
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(d[i]);
                }
                int[] count = new int[d.Length];
                for (int i = 0; i < n; i++)
                {
                    count[i] = 1;
                }
                for (int i = 0; i < n; i++)
                {
                    int k = i;
                    while (d[k] == d[k + 1])
                    {
                        count[i]++;
                        for (int j = i; j < n - 1; j++)
                        {
                            d[j] = d[j + 1];
                        }
                        d[n - 1] = null;
                        n--;
                    }
                }
                Console.WriteLine("合并后打印并输出词频：");
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(count[i]);
                    Console.WriteLine(d[i]);
                }
                int temp;
                string Stemp;
                Console.WriteLine("词频排序后打印：");
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (count[j] > count[i])
                        {
                            temp = count[i];
                            count[i] = count[j];
                            count[j] = temp;
                            Stemp = d[i];
                            d[i] = d[j];
                            d[j] = Stemp;
                        }
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(count[i]);
                    Console.WriteLine(d[i]);
                }
                Console.WriteLine("请输入你想知道个数的单词的长度：");
                int p = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    if (d[i].Length == p)
                    {
                        Console.WriteLine(count[i]);
                        Console.WriteLine(d[i]);
                    }
                }
                Console.WriteLine(n);
                Console.WriteLine(c.Length);
                Console.ReadKey();
            }
        }
    }

