using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace ConsoleApp3
{
    
        // 打印信息
        public class Dis
        {
            private string Filename;    // 文件名
            private string[] sParameter; // 参数数组  

        }

        public class Tongji
        {


        }
        //新建一个输出类

        class Program
        {
            static void Main(string[] args)
            {
                string message = Console.ReadLine();               // 得到输入命令
                string[] arr = message.Split(' '); // 分割命令
                string[] sParameter = new string[arr.Length - 1];// 获取命令参数数组       
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    sParameter[i] = arr[i];
                }
                // 获取文件名
                string Filename = arr[arr.Length - 1];


                FileStream file = new FileStream(Filename, FileMode.Open, FileAccess.ReadWrite);
                //打开文件         
                StreamReader sr = new StreamReader(file);
                string str = sr.ReadToEnd();
               sr.Close();
            file.Close();
            WC wc = new WC();
                wc.BaseCount(str);
               // wc.CountWords(str,9);
                
               
                wc.Display(sParameter, Filename, str);
            //重新打

        }




        }
    }

           