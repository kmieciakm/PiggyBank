namespace PiggyBank.Expanses.Shared.Queries;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : notnull, IQuery<TResult>;
}
