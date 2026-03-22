using Microsoft.EntityFrameworkCore;
using PiggyBank.Expanses.Persistence;
using PiggyBank.Expanses.Shared.Commands;

namespace PiggyBank.Expanses.Features.Categories.DeleteCategory;

internal class DeleteCategoryCommandHandler(IDbContextFactory<ExpensesDbContext> dbContextFactory)
    : ICommandHandler<DeleteCategoryCommand>
{
    private readonly IDbContextFactory<ExpensesDbContext> _dbContextFactory = dbContextFactory;

    public async Task HandleAsync(DeleteCategoryCommand command, CancellationToken cancellationToken = default)
    {
        var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        var category = await dbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == command.CategoryId, cancellationToken);

        if (category is not null)
        {
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
