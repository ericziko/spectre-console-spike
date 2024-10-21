namespace ConsoleApp.Commands.CreateProject;

public interface IProjectManager
{
    string[] ProjectTypes { get; }

    Task CreateProjectAsync(string projectType, CancellationToken cancellationToken);
}