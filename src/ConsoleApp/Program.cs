// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.NamingConventionBinder;
using System.CommandLine.Parsing;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;

public static class Program {

    public static int Main(string[] args) {
        var rootCommand = new RootCommand {
            new HelloCommand()
        };

        var builder = new CommandLineBuilder(rootCommand).UseDefaults().UseDependencyInjection(services => {
            // Register your services here and use them in your DI-activated command handlers
            // [...]
        });

        return builder.Build().Invoke(args);
    }

}