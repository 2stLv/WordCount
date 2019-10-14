
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            WordBasis.wordbasis = new WordBasis();
            string[] word = { "sada", "fewa", "reht", "tyyn" };//测试方法得到的结果单词字符长度是否超过规定的4
            string a = File.ReadAllText(@"D:\test.txt");
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(word[i], WordBasis.CountWord(a)[i]);
            }//测试CountWord方法得到的结果单词前四位是否都为字母
            string b = File.ReadAllText(@"D:\test1.txt");
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(word[i], WordBasis.CountWord(b)[i]);
            }
        }
        public void CountCharTest()
        {
            WordBasis.wordbasis = new WordBasis();
            int Num = 12;//测试CountWord得到的结果字符数
            string a = File.ReadAllText(@"D:\test2.txt");
            Assert.AreEqual(Num, WordBasis.CountWord(a));//测试CountWord得到的结果字符数是否符合要求
            string b = File.ReadAllText(@"C:\test3.txt");
            Assert.AreEqual(Num, WordBasis.CountWord(b));
        }
        public void CountLineTest()
        {
            WordBasis.wordbasis = new WordBasis();
            int Num = 4;//测试得到的行数（不含空行）是否符合要求
            string content5 = File.ReadAllText(@"D:\test2.txt");
            Assert.AreEqual(Num, WordBasis.CountLine(content5));//测试得到的结果行数（含空行）是否符合要求
            string content6 = File.ReadAllText(@"D:\test2.txt");
            Assert.AreEqual(Num, WordBasis.CountLine(content6));
        }
    }
}
