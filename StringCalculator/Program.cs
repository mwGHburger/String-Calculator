using System.Linq;
using System;
using System.Collections.Generic;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new StringCalculator();
            var str = "[*][%]";
            var arr = str.Split(new string[] {
                "][",
                "[",
                "]",
            }, StringSplitOptions.None);
            
            var list = new List<string>();
            foreach(var item in arr)
            {
                if(item.Length > 0)
                {
                    list.Add(item);
                }
            }
            System.Console.WriteLine(list.Count);
        }
    }
}
