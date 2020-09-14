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
                var delimiter = IsolateDelimiter(text);
                var newText = FormatString(text, delimiter);
                string[] delimiters = CreateDelimitersArray(delimiter);
                var stringNumbers = newText.Split(delimiters, StringSplitOptions.None);
                total = SumStringNumbersInArray(newText, total, delimiters);
            }
            else
            {
                string[] delimiters = CreateDelimitersArray();
                total = SumStringNumbersInArray(text, total, delimiters);
            }

           return total;
        }

        public int SumStringNumbersInArray(string text, int total, string[] delimiters)
        {
            var stringNumbers = text.Split(delimiters, StringSplitOptions.None);
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

        public string IsolateDelimiter(string text)
        {
            var end = text.IndexOf("\n") - 2;
            var delimiter = text.Substring(2,end);
            if(delimiter[0] == '[')
            {   
                // CONVERT TO ARRAY
                return delimiter.Substring(1, delimiter.Length - 2);
            }
            return text.Substring(2,end);
        }

        public string FormatString(string text, string delimiter)
        {
            if (delimiter.Length > 1)
            {
                delimiter = $"[{delimiter}]";
            }
            // CONVERT ARRAY INTO NEW DELIMITER
            var newDelimiter = $"//{delimiter}\n";

            return text.Split(new string[]
                {
                newDelimiter
                }, StringSplitOptions.None
            )[1];
        }

        public string[] CreateDelimitersArray(string delimiter = ",")
        {
            return new string[] {
                ",",
                "\n",
                delimiter
            };
        }
    }
}