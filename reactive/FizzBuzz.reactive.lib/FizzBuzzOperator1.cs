using System.Reactive.Linq;

namespace FizzBuzz.reactive.lib;

public static class FizzBuzzOperator1
{
    public static IObservable<string> FizzBuzz1(this IObservable<int> observable) => 
        observable.Select(FizzBuzzer.GetFizzBuzz);
}