using System.Reactive;
using System.Reactive.Linq;
using Xunit.Abstractions;

namespace FizzBuzz.reactive.tests;

public class TestOutputObserver<T> : ObserverBase<T>
{
    private readonly ITestOutputHelper _output;

    public TestOutputObserver(ITestOutputHelper output)
    {
        _output = output;
    }
    
    protected override void OnNextCore(T value) => 
        _output.WriteLine($"OnNext: {value}");

    protected override void OnErrorCore(Exception error) => 
        _output.WriteLine($"OnError: {error.Message}");

    protected override void OnCompletedCore() => 
        _output.WriteLine("OnCompleted");
}

internal static class ObservableExtensions
{
    public static IObservable<T> TestOutput<T>(this IObservable<T> source, ITestOutputHelper output) =>
        source.Do(observer: new TestOutputObserver<T>(output));
}