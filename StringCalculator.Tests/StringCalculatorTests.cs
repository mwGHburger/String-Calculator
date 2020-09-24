using System;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorTest
    {
        [Fact]
        public void ReturnZero_FromEmptyString()
        {
            var calculator = new StringCalculator();
            var expected = 0;

            var actual = calculator.Add("");
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1,"1")]
        [InlineData(3,"3")]
        public void ReturnNumber_FromSingleStringNumber(int expected, string input)
        {
            var calculator = new StringCalculator();
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3,"1,2")]
        [InlineData(8,"3,5")]
        [InlineData(1000,"999,1")]
        public void ReturnSum_FromTwoNumber(int expected, string input)
        {
            var calcualtor = new StringCalculator();

            var actual = calcualtor.Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(6,"1,2,3")]
        [InlineData(20,"3,5,3,9")]
        public void ReturnSum_FromAnyAmountOfNumbers(int expected, string input)
        {
            var calculator = new StringCalculator();

            var actual = calculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(6,"1,2\n3")]
        [InlineData(20,"3\n5\n3,9")]
        public void Accept_NewLineBreaksAndCommas(int expected, string input)
        {
            var calculator = new StringCalculator();

            var actual = calculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SupportDifferentDelimiters()
        {
            var calculator = new StringCalculator();
            var expected = 3;

            var actual = calculator.Add("//;\n1;2");
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowException_ForNegatives()
        {
            var calculator = new StringCalculator();
            var ex = Assert.Throws<ArgumentException>(() => calculator.Add("-1,2,-3"));
            Assert.Equal("Negatives not allowed: -1, -3", ex.Message);
        }

        [Theory]
        [InlineData(2,"1000,1001,2")]
        [InlineData(1000,"999,1")]
        public void IgnoreNumbers_GreaterThanOrEqualTo1000(int expected, string input)
        {
            var calculator = new StringCalculator();

            var actual = calculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AllowDelimiters_OfAnyLength()
        {
            var calculator = new StringCalculator();
            var expected = 6;

            var actual = calculator.Add("//[***]\n1***2***3");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Allow_MultipleDelimiters()
        {
            var calculator = new StringCalculator();
            var expected = 6;

            var actual = calculator.Add("//[*][%]\n1*2%3");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HandleMultipleDelimiters_WithLengthMoreThan1()
        {
            var calculator = new StringCalculator();
            var expected = 10;

            var actual = calculator.Add("//[***][#][%]\n1***2#3%4");

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(6,"//[*1*][%]\n1*1*2%3")]
        [InlineData(6,"//[1**][%]\n11**2%3")]
        public void HandleDelimiters_ThatIncludeNumbers(int expected, string input)
        {
            var calculator = new StringCalculator();

            var actual = calculator.Add(input);

            Assert.Equal(expected, actual);
        }
    }
}
