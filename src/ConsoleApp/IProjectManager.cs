namespace ConsoleApp;

public interface IProjectManager
{
    string[] ProjectTypes { get; }

    Task CreateProjectAsync(string projectType, CancellationToken cancellationToken);
}