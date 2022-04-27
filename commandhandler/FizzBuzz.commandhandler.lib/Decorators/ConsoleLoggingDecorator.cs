using FizzBuzz.commandhandler.lib.Handlers;

namespace FizzBuzz.commandhandler.lib.Decorators;

public class ConsoleLoggingDecorator<TRequest, TResponse> 
    : IDecorator<TRequest, TResponse>
{
    private readonly ICommandHandler<TRequest, TResponse> _inner;

    public ConsoleLoggingDecorator(ICommandHandler<TRequest, TResponse> inner)
    {
        _inner = inner;
    }
    
    public TResponse Handle(TRequest request)
    {
        var result = _inner.Handle(request);

        Console.WriteLine($"request: {request}, response: {result}");

        return result;
    }
}