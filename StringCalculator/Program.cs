using System.Linq;
using System;
using System.Collections.Generic;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var cal = new StringCalculator();
            var test = "//[1**][%]\n11**2%3";
            System.Console.WriteLine(cal.Add(test));

        }
    }
}
