using System;
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

            if (text[0] == '/')
            {
                var delimiter = this.IsolateDelimiter(text);
                var newText = text.Split(new string[]
                    {
                        $"//{delimiter}\n"
                    }, StringSplitOptions.None
                )[1];

                char[] delimiters = new char[] {
                    ',',
                    '\n',
                    delimiter
                };

                var stringNumbers = newText.Split(delimiters);
                
                foreach(string number in stringNumbers)
                {
                    total += Convert.ToInt32(number);
                }
            }
            else
            {
                char[] delimiters = new char[] {
                    ',',
                    '\n'
                };

                var stringNumbers = text.Split(delimiters);
                
                foreach(string number in stringNumbers)
                {
                    total += Convert.ToInt32(number);
                }
            }

           return total;
        }

        public char IsolateDelimiter(string text)
        {
            return text[2];
        }
    }
}