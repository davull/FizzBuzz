namespace FizzBuzz.commandhandler.lib.Commands;

public record FizzBuzzCommand(int Number);

public record FizzBuzzCommandResult(string Result);