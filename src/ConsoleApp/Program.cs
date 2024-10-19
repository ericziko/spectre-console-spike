// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.NamingConventionBinder;
using System.CommandLine.Parsing;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace ConsoleApp;

public static class Program {

    public static int Main(string[] args) {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        var rootCommand = new RootCommand {
            new HelloCommand()
        };

        var builder = new CommandLineBuilder(rootCommand).UseDefaults().UseDependencyInjection(services => {
            
            // Register your services here and use them in your DI-activated command handlers
            // [...]
        });
        builder.UseDefaults();
        builder.UseDependencyInjection(services => {
            services.AddSingleton(AnsiConsole.Console);
        });

        return builder.Build().Invoke(args);
    }

}