using System.CommandLine;

namespace ConsoleApp.Commands.Hello;

public class HelloCommandOptionsHandler : ICommandOptionsHandler<HelloCommandOptions>
{
    private readonly IConsole _console;

    // Inject anything here, no more hard dependency on System.CommandLine
    public HelloCommandOptionsHandler(IConsole console)
    {
        this._console = console;
    }

    public Task<int> HandleAsync(HelloCommandOptions options, CancellationToken cancellationToken)
    {
        this._console.WriteLine($"Hello {options.To}!");
        return Task.FromResult(0);
    }
}