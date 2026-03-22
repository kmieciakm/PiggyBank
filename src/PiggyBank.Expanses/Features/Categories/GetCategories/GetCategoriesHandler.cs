using Microsoft.EntityFrameworkCore;
using PiggyBank.Expanses.Persistence;
using PiggyBank.Expanses.Shared.Queries;

namespace PiggyBank.Expanses.Features.Categories.GetCategories;

internal class GetCategoriesHandler(IDbContextFactory<ExpensesDbContext> dbContextFactory)
    : IQueryHandler<GetCategories, IEnumerable<CategoryDto>>
{
    private readonly IDbContextFactory<ExpensesDbContext> _dbContextFactory = dbContextFactory;

    public async Task<IEnumerable<CategoryDto>> HandleAsync(GetCategories query, CancellationToken cancellationToken = default)
    {
        var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await dbContext.Categories
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Color = c.Color
            })
            .ToListAsync(cancellationToken);
    }
}
