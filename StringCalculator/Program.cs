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
            var test = "//[*][%]\n1*2%3";
            cal.Add(test);

        }
    }
}
