using System;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorShould
    {
        [Fact]
        public void ReturnZeroFromEmptyString()
        {
            var calculator = new StringCalculator();
            var expected = 0;

            var actual = calculator.Add("");
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnNumberFromSingleStringNumber()
        {
            var calculator = new StringCalculator();
            var expected1 = 1;
            var expected2 = 3;

            var actual1 = calculator.Add("1");
            var actual2 = calculator.Add("3");

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }

        [Fact]
        public void ReturnSumFromTwoNumber()
        {
            var calcualtor = new StringCalculator();
            var expected1 = 3;
            var expected2 = 8;

            var actual1 = calcualtor.Add("1,2");
            var actual2 = calcualtor.Add("3,5");

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }

        [Fact]
        public void ReturnSumFromAnyAmountOfNumbers()
        {
            var calculator = new StringCalculator();
            var expected1 = 6;
            var expected2 = 20;

            var actual1 = calculator.Add("1,2,3");
            var actual2 = calculator.Add("3,5,3,9");

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }

        [Fact]
        public void AcceptNewLineBreaksAndCommas()
        {
            var calculator = new StringCalculator();
            var expected1 = 6;
            var expected2 = 20;

            var actual1 = calculator.Add("1,2\n3");
            var actual2 = calculator.Add("3\n5\n3,9");

            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }

        [Fact]
        public void SupportDifferentDelimiters()
        {
            var calculator = new StringCalculator();
            var expectedDelimiter = ";";
            var expected = 3;

            var actualDelimiter = calculator.CreateDelimiterList("//;\n1;2")[2];
            var actual = calculator.Add("//;\n1;2");

            Assert.Equal(expectedDelimiter, actualDelimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowExceptionForNegatives()
        {
            var calculator = new StringCalculator();
            Assert.Throws<ArgumentException>(() => calculator.Add("-1,2,-3"));

            try
            {
                calculator.Add("-1,2,-3");
            }
            catch(ArgumentException e)
            {
                var expected = "Throws exception with Negatives not allowed: -1, -3";
                var actual = e.Message;

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void IgnoreNumbersGreaterThanOrEqualTo1000()
        {
            var calculator = new StringCalculator();
            var expected = 2;

            var actual = calculator.Add("1000,1001,2");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AllowDelimitersOfAnyLength()
        {
            var calculator = new StringCalculator();
            var expected = 6;

            var actual = calculator.Add("//[***]\n1***2***3");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AllowMultipleDelimiters()
        {
            var calculator = new StringCalculator();
            var expected = 6;

            var actual = calculator.Add("//[*][%]\n1*2%3");
            // [ , ***, ,%, ]
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HandleMultipleDelimitersWithLengthMoreThan1()
        {
            var calculator = new StringCalculator();
            var expected = 10;

            var actual = calculator.Add("//[***][#][%]\n1***2#3%4");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HandleDelimitersThatIncludeNumbers()
        {
            var calculator = new StringCalculator();
            var expected = 6;

            var actual = calculator.Add("//[*1*][%]\n1*1*2%3");

            Assert.Equal(expected, actual);
        }
    }
}
