namespace PiggyBank.Expanses.Shared.Commands;

internal interface ICommandHandler<in TCommand> where TCommand : notnull, ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
