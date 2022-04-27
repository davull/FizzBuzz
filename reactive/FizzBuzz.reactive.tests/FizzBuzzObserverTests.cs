using System.Reactive.Linq;
using FizzBuzz.reactive.lib;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace FizzBuzz.reactive.tests;

public class FizzBuzzObservableExtensionsTests
{
    private const string Fizz = "Fizz";
    private const string Buzz = "Buzz";
    private const string FizzBuzz = Fizz + Buzz;

    private readonly ITestOutputHelper _output;

    public FizzBuzzObservableExtensionsTests(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    public async Task GetFizz(int i)
    {
        // Arrange
        var observable = CreateFizzBuzzObservable(i);

        // Act
        var actual = await observable.SingleAsync();

        // Assert
        actual.Should().BeEquivalentTo(Fizz);
    }
    
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    public async Task GetBuzz(int i)
    {
        // Arrange
        var observable = CreateFizzBuzzObservable(i);

        // Act
        var actual = await observable.SingleAsync();
        
        // Assert
        actual.Should().BeEquivalentTo(Buzz);
    }

    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(45)]
    public async Task GetFizzBuzz(int i)
    {
        // Arrange
        var observable = CreateFizzBuzzObservable(i);

        // Act
        var actual = await observable.SingleAsync();
        
        // Assert
        actual.Should().BeEquivalentTo(FizzBuzz);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4)]
    public async Task GetNumber(int i)
    {
        // Arrange
        var observable = CreateFizzBuzzObservable(i);

        // Act
        var actual = await observable.SingleAsync();
        
        // Assert
        actual.Should().BeEquivalentTo(i.ToString());
    }
    
    [Fact]
    public async Task GetFizzBuzz_From1To100()
    {
        // Arrange
        var observable = Observable
            .Range(start: 1, count: 100)
            .FizzBuzz()
            .TestOutput(_output);

        const string expected = "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 " +
                                "FizzBuzz 16 17 Fizz 19 Buzz Fizz 22 23 Fizz Buzz 26 " +
                                "Fizz 28 29 FizzBuzz 31 32 Fizz 34 Buzz Fizz 37 38 Fizz " +
                                "Buzz 41 Fizz 43 44 FizzBuzz 46 47 Fizz 49 Buzz Fizz 52 53 " +
                                "Fizz Buzz 56 Fizz 58 59 FizzBuzz 61 62 Fizz 64 Buzz Fizz " +
                                "67 68 Fizz Buzz 71 Fizz 73 74 FizzBuzz 76 77 Fizz 79 Buzz " +
                                "Fizz 82 83 Fizz Buzz 86 Fizz 88 89 FizzBuzz 91 92 Fizz 94 " +
                                "Buzz Fizz 97 98 Fizz Buzz";
        // Act
        var actual = await observable
            .Aggregate((s, s1) => s + " " + s1)
            .SingleAsync();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }


    private IObservable<string> CreateFizzBuzzObservable(int i) =>
        Observable.Return(i)
            .FizzBuzz()
            .TestOutput(_output);
}