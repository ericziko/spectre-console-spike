using System.CommandLine;
using Spectre.Console;

namespace ConsoleApp;

public class CreateProjectCommandOptionsHandler : ICommandOptionsHandler<CreateProjectCommandOptions>
{
    private readonly IAnsiConsole _console;
    private readonly IProjectManager _projectManager;

    public CreateProjectCommandOptionsHandler(IAnsiConsole console, IProjectManager projectManager)
    {
        this._console = console;
        this._projectManager = projectManager;
    }

    public async Task<int> HandleAsync(CreateProjectCommandOptions options, CancellationToken cancellationToken)
    {
        var prompt = new SelectionPrompt<string>()
            .Title("What [green]type of project[/] would you like to create?")
            .AddChoices(this._projectManager.ProjectTypes);

        var projectType = await prompt.ShowAsync(this._console, cancellationToken);
        this._console.MarkupLineInterpolated($"You selected [green]{projectType}[/].");

        await this._projectManager.CreateProjectAsync(projectType, cancellationToken);

        return 0;
    }
}