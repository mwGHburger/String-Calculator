using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class StringCalculator
    {
        public StringCalculator()
        {

        }

        public int Add(string text)
        {
            var total = 0;
            if (String.IsNullOrEmpty(text)) return total;

            if (text.Contains("//"))
            {
                System.Console.WriteLine("Contains //");
                var delimiterList = CreateDelimiterList(text);
                var stringToSum = ExtractStringToSum(text);
                string[] delimiterArray = delimiterList.ToArray();
                var stringNumbers = stringToSum.Split(delimiterArray, StringSplitOptions.None);
                total = SumStringNumbers(stringToSum, total, delimiterArray);
            }
            else
            {
                var delimiterList = CreateDelimiterList();
                string[] delimiterArray = delimiterList.ToArray();
                total = SumStringNumbers(text, total, delimiterArray);
            }

           return total;
        }

        public int SumStringNumbers(string text, int total, string[] delimiterArray)
        {
            System.Console.WriteLine("Invoke SumStringNumbersInArray method");
            
            var stringNumbers = text.Split(delimiterArray, StringSplitOptions.None);
            var negativeStringNumbers = new List<string>();
            foreach(string number in stringNumbers)
            {
                if (Convert.ToInt32(number) < 0)
                {
                    negativeStringNumbers.Add(number);
                }
                if (Convert.ToInt32(number) < 1000)
                {
                    total += Convert.ToInt32(number);
                }
            }

            if (negativeStringNumbers.Count > 0)
            {
                throw new ArgumentException($"Throws exception with Negatives not allowed: {String.Join(", ", negativeStringNumbers)}");
            }

            return total;
        }

        public List<string> CreateDelimiterList(string text = "")
        {
            System.Console.WriteLine("Invoke IsolateDelimiter method");
            var delimiterList = new List<string>() {
                ",",
                "\n"
            };

            if (text == "")
            {
                return delimiterList;
            }
            var end = text.IndexOf("\n") - 2;
            var delimiterString = text.Substring(2,end);
            if(delimiterString[0] == '[')
            {   
                var delimiterArray = delimiterString.Split(new string[] {
                    "][",
                    "[",
                    "]",
                 }, StringSplitOptions.None);
                // TODO: REFACTOR
                foreach(var item in delimiterArray)
                {
                    if(item.Length > 0)
                    {
                        delimiterList.Add(item);
                    }
                }
                return delimiterList;
            }
            delimiterList.Add(text.Substring(2,end));
            return delimiterList;
        }

        public string ExtractStringToSum(string text)
        {
            System.Console.WriteLine("Invoke FormatString method");
            var end = text.IndexOf("\n") + 1;
            return text.Substring(end);
        }
    }
}