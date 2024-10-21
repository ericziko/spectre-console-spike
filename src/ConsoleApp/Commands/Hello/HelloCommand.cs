using System.CommandLine;

namespace ConsoleApp.Commands.Hello;

public class HelloCommand : Command<HelloCommandOptions, HelloCommandOptionsHandler>
{
    // Keep the hard dependency on System.CommandLine here
    public HelloCommand()
        : base("hello", "Say hello to someone")
    {
        this.AddOption(new Option<string>("--to", "The person to say hello to"));
    }
}