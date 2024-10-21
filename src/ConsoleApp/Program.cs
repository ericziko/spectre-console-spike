// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using ConsoleApp.Commands.CreateProject;
using ConsoleApp.Commands.Hello;
using ConsoleApp.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace ConsoleApp;

public static class Program {

    public static int Main(string[] args) {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var rootCommand = new RootCommand {
            new HelloCommand(),
            new CreateProjectCommand()
        };

        var builder = new CommandLineBuilder(rootCommand).UseDefaults()
        builder.UseDefaults();
        builder.UseDependencyInjection(services => {
            services.AddSingleton<IProjectManager, NoopProjectManager>();
            services.AddSingleton(AnsiConsole.Console);
        });

        return builder.Build().Invoke(args);
    }

}