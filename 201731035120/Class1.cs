using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace ConsoleApp3
{
    public class WC
    {
        private string Filename;    // 文件名
        private string[] sParameter; // 参数数组  
        private int charcount;      // 字符数
        private int wordcount;      // 单词数
        private int linecount;      // 总行数
        private int u = 0;
        public string[] Sp
        {
            get { return sParameter; }
            set { sParameter = value; }
        }
        public int Charcount
        {
            get { return charcount; }
            set { charcount = value; }
        }
        public int Wordcount
        {
            get { return wordcount; }
            set { wordcount = value; }
        }
        public int Linecount
        {
            get { return linecount; }
            set { linecount = value; }
        }
        public Dictionary<string, int> putout1 = new Dictionary<string, int>();
        public Dictionary<string, int> putout2 = new Dictionary<string, int>();
        // 参数控制信息
        public Dictionary<string, int> DI1
        {
            get { return putout1; }
            set { putout1 = value; }
        }
        public Dictionary<string, int> DI2
        {
            get { return putout2; }
            set { putout2 = value; }
        }
        // 统计基本信息：字符数 单词数 行数
        public void BaseCount(string str)
        {

            charcount = 0;

            linecount = 0;
            //定义一个字符数组
            //输出了从未文件读到的东西Console.WriteLine(str);
            char[] chars = str.ToCharArray();

            /* for (int i = 0; i < chars.Length; i++)
             {
                 Console.WriteLine((int)chars[i]);
             } */
            foreach (int c in chars)
            {
                if (c == 9 || c == 10 || c >= 32 && c <= 126)
                {
                    charcount++;//字符个数                  
                }
                if (c == 10)
                {
                    linecount++; // 统计行数
                }
            }
            string[] words = Regex.Split(str, @"\W+");

            Console.WriteLine("characters：{0}", charcount);//输出字符数
            putout1.Add("characters", charcount);
            Console.WriteLine("lines：{0}", linecount);//输出行数
            putout1.Add("lines", linecount);
            wordcount = words.Length;
            Console.WriteLine("words ：{0}", wordcount);//输出单词数
            putout1.Add("words", wordcount);
        }
        //统计单词个数；
        public void CountWords(string y, int v)
        {
            Dictionary<string, int> fre = new Dictionary<string, int>();
            string x = y.ToLower();
            string[] words = Regex.Split(x, @"\W+");

            foreach (string word in words)
            {
                if (fre.ContainsKey(word))
                {
                    fre[word]++;
                }
                else
                {
                    fre[word] = 1;
                }
            }
            //字典序(新建了一个var ，fre是要被排序的Dictionary<string, int> fre，)
            var frac = (from ac in fre orderby ac.Key ascending select ac);
            //按值的排序
            var fres = (from ob in frac orderby ob.Value descending select ob);
            int j = 0;
            foreach (KeyValuePair<string, int> k in fres)
            {
                Console.WriteLine("{0}:{1}", k.Key, k.Value);
                putout2.Add(k.Key, k.Value);
                j++;
                if (j == v) break;
            }
        }
        public void Display(string[] sParameter, string Filename, string str)
        {
            this.sParameter = sParameter;
            this.Filename = Filename;
            
            for (int i = 0; i < sParameter.Length; i++)
            {
                if (sParameter[i] == "-n")//表示输出最多的前[number]个单词
                {
                     u = int.Parse(sParameter[i + 1]);
                    CountWords(str, u);

                }
                if (sParameter[i] == "-o")//参数设定生成文件的存储路径
                {
                    Put(Filename);
                }
            }
        }
        public void Put(string Filename)
        {
            FileStream file = new FileStream(Filename, FileMode.Open, FileAccess.Write);

            StreamWriter sw = new StreamWriter(file);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            foreach (var f in putout1)   //putout1，putout2是，把要输出的东西加到 Dictionary<string, int> putout1里
            {
                sw.WriteLine("{0}:{1}", f.Key, f.Value);
            }
            foreach (var f in putout2)
            {
                sw.WriteLine("{0}:{1}", f.Key, f.Value);
            }
            sw.Close();
            file.Close();

        }
    }
}
    