namespace ConsoleApp.Commands;

public interface ICommandOptionsHandler<in TOptions>
    where TOptions : ICommandOptions {

    Task<int> HandleAsync(TOptions options, CancellationToken cancellationToken);

}