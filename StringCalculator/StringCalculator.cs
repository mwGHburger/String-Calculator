using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class StringCalculator
    {
        public StringCalculator()
        {

        }

        public int Add(string stringInput)
        {
            var total = 0;
            if (String.IsNullOrEmpty(stringInput)) return total;

            if (stringInput.Contains("//"))
            {
                var delimiterList = CreateDelimiterList(stringInput);
                var stringToSum = ExtractStringToSum(stringInput);
                string[] delimiterArray = delimiterList.ToArray();
                var stringNumbers = stringToSum.Split(delimiterArray, StringSplitOptions.None);
                total = SumStringNumbers(stringToSum, total, delimiterArray);
            }
            else
            {
                var delimiterList = CreateDelimiterList();
                string[] delimiterArray = delimiterList.ToArray();
                total = SumStringNumbers(stringInput, total, delimiterArray);
            }

           return total;
        }

        public int SumStringNumbers(string text, int total, string[] delimiterArray)
        {
            var stringNumbers = text.Split(delimiterArray, StringSplitOptions.None);
            var negativeStringNumbers = new List<string>();
            foreach(string number in stringNumbers)
            {
                if (Convert.ToInt32(number) < 0) negativeStringNumbers.Add(number);
                if (Convert.ToInt32(number) < 1000) total += Convert.ToInt32(number);
            }

            if (negativeStringNumbers.Count > 0)
            {
                throw new ArgumentException($"Negatives not allowed: {String.Join(", ", negativeStringNumbers)}");
            }

            return total;
        }

        public List<string> CreateDelimiterList(string text = "")
        {
            var delimiterList = new List<string>() {
                ",",
                "\n"
            };

            if (text == "")
            {
                return delimiterList;
            }
            var indexOfFirstLineBreak = text.IndexOf("\n") - 2;
            var delimiterString = text.Substring(2,indexOfFirstLineBreak);
            if(delimiterString[0] == '[')
            {   
                var delimiterArray = delimiterString.Split(new string[] {
                    "[",
                    "]",
                }, StringSplitOptions.RemoveEmptyEntries);
                foreach(var item in delimiterArray)
                {
                    delimiterList.Add(item);
                }
                return delimiterList;
            }
            delimiterList.Add(delimiterString);
            return delimiterList;
        }

        public string ExtractStringToSum(string text)
        {
            var end = text.IndexOf("\n") + 1;
            return text.Substring(end);
        }
    }
}