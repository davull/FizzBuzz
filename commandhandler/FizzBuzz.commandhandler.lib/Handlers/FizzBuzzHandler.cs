using FizzBuzz.commandhandler.lib.Commands;

namespace FizzBuzz.commandhandler.lib.Handlers;

public class FizzBuzzHandler : ICommandHandler<FizzBuzzCommand, FizzBuzzCommandResult>
{
    private const string Fizz = "Fizz";
    private const string Buzz = "Buzz";
    private const string FizzBuzz = Fizz + Buzz;

    public FizzBuzzCommandResult Handle(FizzBuzzCommand request) =>
        new(Result: GetFizzBuzz(request.Number));

    private static string GetFizzBuzz(int i)
    {
        if (IsFizzBuzz(i)) return FizzBuzz;
        if (IsFizz(i)) return Fizz;
        if (IsBuzz(i)) return Buzz;
        
        return i.ToString();
    }
    
    private static bool IsFizzBuzz(int i) => IsFizz(i) && IsBuzz(i);
    
    private static bool IsFizz(int i) => IsDivisibleBy(i: i, divisor: 3);
    private static bool IsBuzz(int i) => IsDivisibleBy(i: i, divisor: 5);

    private static bool IsDivisibleBy(int i, int divisor) => i % divisor == 0;
}