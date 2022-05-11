namespace FizzBuzz.simple.IOSP.lib;

internal static class FizzBuzzOperation
{
    private const string Fizz = "Fizz";
    private const string Buzz = "Buzz";
    private const string FizzBuzz = Fizz + Buzz;

    public static string TransformNumber(int number)
    {
        if (IsFizzBuzz(number)) return FizzBuzz;
        if (IsFizz(number)) return Fizz;
        if (IsBuzz(number)) return Buzz;

        return number.ToString();
    }

    private static bool IsFizzBuzz(int i) => IsFizz(i) && IsBuzz(i);
    private static bool IsFizz(int i) => i % 3 == 0;
    private static bool IsBuzz(int i) => i % 5 == 0;
}