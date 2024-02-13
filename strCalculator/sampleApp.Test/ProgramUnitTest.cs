using NUnit.Framework;
using sampleApp;

namespace sampleApp.Test;

public class ProgramUnitTest
{
    [TestCase("", 0, TestName = "Check for empty string and return 0")]
    [TestCase("1", 1, TestName = "Check for only one number and return same number")]
    [TestCase("1,2", 3, TestName = "Check for two numbers and return their addition")]
    [TestCase("1,2,3", 6, TestName = "Check for more numbers and return their addition")]
    [TestCase("1\n2,3", 6, TestName = "Check for New line and comma delimiters")]
    [TestCase("//;\n2;3", 5, TestName = "Custom delimiter")]
    [TestCase("1001,2", 2, TestName = "Numbers bigger than 1000 are ignored")]
    public void stringCalculatorAddPositiveNumbersReturnsSumValue(string input, int expectedResult)
    {
        var result = Program.Add(input);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("1,-2", "-2")]
    [TestCase("1,-2,-3", "-2, -3")]
    [TestCase("3//2\n1;-2,-3", "-2, -3")]
    public void stringCalculatorAddNegativeNumbersThrowsException(string input, string expectedNegativeValues)
    {
        var exception = Assert.Throws<NegativesNotAllowedException>(() => Program.Add(input));
        Assert.That(exception!.Message, Is.EqualTo($"Negatives values not allowed: {expectedNegativeValues}"));
    }
}