namespace PiggyBank.Expanses.Shared.Queries;

internal interface IQueryHandler<in TQuery, TResult> where TQuery : notnull, IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}
