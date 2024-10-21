using ConsoleApp.Commands.CreateProject;
using FakeItEasy;
using Spectre.Console.Testing;

namespace ConsoleApp.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        // From https://anthonysimmon.com/beautiful-interactive-console-apps-with-system-commandline-and-spectre-console/
        
        var projectManager = A.Fake<IProjectManager>();
        A.CallTo(() => projectManager.ProjectTypes).Returns(["a", "b", "c", "d"]);

        var console = new TestConsole();
        console.Profile.Capabilities.Interactive = true;
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.DownArrow);
        console.Input.PushKey(ConsoleKey.Enter);

        var handler = new CreateProjectCommandOptionsHandler(console, projectManager);

        var result = await handler.HandleAsync(new CreateProjectCommandOptions(), CancellationToken.None);

        Assert.That(result, Is.EqualTo(0));

        A.CallTo(() => projectManager.CreateProjectAsync("c", CancellationToken.None))
            .MustHaveHappenedOnceExactly();
        Assert.Pass();
    }
}