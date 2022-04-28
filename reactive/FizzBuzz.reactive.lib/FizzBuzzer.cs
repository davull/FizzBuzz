namespace FizzBuzz.reactive.lib;

internal static class FizzBuzzer
{
    public const string Fizz = "Fizz";
    public const string Buzz = "Buzz";
    public const string FizzBuzz = Fizz + Buzz;
    
    public static string GetFizzBuzz(int i)
    {
        if (IsFizzBuzz(i)) return FizzBuzz;
        if (IsFizz(i)) return Fizz;
        if (IsBuzz(i)) return Buzz;
        
        return i.ToString();
    }

    public static bool IsNotFizzAndNotBuzz(int i) => !IsFizz(i) && !IsBuzz(i);
    
    public static bool IsOnlyFizz(int i) => IsFizz(i) && !IsBuzz(i);
    
    public static bool IsOnlyBuzz(int i) => IsBuzz(i) && !IsFizz(i);

    public static bool IsFizzBuzz(int i) => IsFizz(i) && IsBuzz(i);

    private static bool IsFizz(int i) => IsDivisibleBy(i: i, divisor: 3);

    private static bool IsBuzz(int i) => IsDivisibleBy(i: i, divisor: 5);

    private static bool IsDivisibleBy(int i, int divisor) => i % divisor == 0;
}