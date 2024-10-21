namespace ConsoleApp.Commands.CreateProject;

public sealed class NoopProjectManager : IProjectManager
{
    // For demonstrations purposes only
    public string[] ProjectTypes => new[]
    {
        "ASP.NET Core Web API",
        "ASP.NET Core Web App",
        "Class Library",
        "WPF Application",
    };

    public Task CreateProjectAsync(string projectType, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}