using FizzBuzz.commandhandler.lib.Handlers;

namespace FizzBuzz.commandhandler.lib.Decorators;

public interface IDecorator<TRequest, TResponse> 
    : ICommandHandler<TRequest, TResponse>
{
    
}