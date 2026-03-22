namespace PiggyBank.Expanses.Shared.Commands;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : notnull, ICommand;
}
