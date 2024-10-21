using System.CommandLine;

namespace ConsoleApp.Commands.Hello;

public class HelloCommandOptions : ICommandOptions
{
    // Automatic binding with System.CommandLine.NamingConventionBinder
    public string To { get; set; } = string.Empty;
}