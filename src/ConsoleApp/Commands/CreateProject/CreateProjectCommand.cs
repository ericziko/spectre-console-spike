namespace ConsoleApp.Commands.CreateProject;

// Command<,> comes from a previous post https://anthonysimmon.com/true-dependency-injection-with-system-commandline/
public class CreateProjectCommand : Command<CreateProjectCommandOptions, CreateProjectCommandOptionsHandler>
{
    public CreateProjectCommand()
        : base("create-project", "Create a .NET project")
    {
    }
}

// Also add "services.AddSingleton<IProjectManager, NoopProjectManager>()" in the dependency injection setup