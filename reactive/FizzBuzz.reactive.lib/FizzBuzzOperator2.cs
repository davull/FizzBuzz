using System.Reactive.Linq;

namespace FizzBuzz.reactive.lib;

public static class FizzBuzzOperator2
{
    public static IObservable<string> FizzBuzz2(this IObservable<int> source) =>
        Observable.Merge(sources: new[]
        {
            GetFizzObservable(source),
            GetBuzzObservable(source),
            GetFizzBuzzObservable(source),
            GetNumberObservable(source)
        });

    private static IObservable<string> GetNumberObservable(IObservable<int> source) =>
        source
            .Where(FizzBuzzer.IsNotFizzAndNotBuzz)
            .Select(i => i.ToString());

    private static IObservable<string> GetBuzzObservable(IObservable<int> source) =>
        source
            .Where(FizzBuzzer.IsOnlyBuzz)
            .Select(_ => FizzBuzzer.Buzz);

    private static IObservable<string> GetFizzObservable(IObservable<int> source) =>
        source
            .Where(FizzBuzzer.IsOnlyFizz)
            .Select(_ => FizzBuzzer.Fizz);

    private static IObservable<string> GetFizzBuzzObservable(IObservable<int> source) =>
        source
            .Where(FizzBuzzer.IsFizzBuzz)
            .Select(_ => FizzBuzzer.FizzBuzz);
}