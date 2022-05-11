using System.Text;
using FizzBuzz.simple.IOSP.lib;
using FluentAssertions;
using Snapshooter.Xunit;
using Xunit;

namespace FizzBuzz.simple.IOSP.tests;

public class FizzBuzzIntegrationTests
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "Fizz")]
    [InlineData(4, "4")]
    [InlineData(5, "Buzz")]
    [InlineData(6, "Fizz")]
    [InlineData(7, "7")]
    [InlineData(8, "8")]
    [InlineData(9, "Fizz")]
    [InlineData(15, "FizzBuzz")]
    public void GetFizzBuzz_returnsTransformedNumber(int number, string expected)
    {
        // Arrange
        var sb = new StringBuilder();
        
        // Act
        FizzBuzzIntegration.GetFizzBuzz(
            start: number,
            count: 1,
            output: s => sb.AppendLine(s));
        
        // Assert
        var actual = sb.ToString();
        actual.Should().Be(expected + Environment.NewLine);
    }
    
    [Fact]
    public void GetFizzBuzz_from1to100_returnsFizzBuzzOutput()
    {
        // Arrange
        var sb = new StringBuilder();
        
        // Act
        FizzBuzzIntegration.GetFizzBuzz(
            start: 1,
            count: 100,
            output: s => sb.AppendLine(s));
        
        // Assert
        sb.ToString().Should().MatchSnapshot();
    }
}