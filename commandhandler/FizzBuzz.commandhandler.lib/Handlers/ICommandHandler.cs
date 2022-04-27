namespace FizzBuzz.commandhandler.lib.Handlers;

public interface ICommandHandler<TRequest, TResponse>
{
    TResponse Handle(TRequest request);
}