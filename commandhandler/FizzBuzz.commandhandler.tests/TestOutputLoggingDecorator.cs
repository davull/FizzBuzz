using FizzBuzz.commandhandler.lib.Decorators;
using FizzBuzz.commandhandler.lib.Handlers;
using Xunit.Abstractions;

namespace FizzBuzz.commandhandler.tests;

public class TestOutputLoggingDecorator<TRequest, TResponse>
    : IDecorator<TRequest, TResponse>
{
    private readonly ITestOutputHelper _output;
    private readonly ICommandHandler<TRequest, TResponse> _inner;

    public TestOutputLoggingDecorator(
        ITestOutputHelper output, 
        ICommandHandler<TRequest, TResponse> inner)
    {
        _output = output;
        _inner = inner;
    }

    public TResponse Handle(TRequest request)
    {
        var result = _inner.Handle(request);

        _output.WriteLine($"request: {request}, response: {result}");

        return result;
    }
}