using Microsoft.EntityFrameworkCore;
using PiggyBank.Expanses.Persistence;
using PiggyBank.Expanses.Shared.Commands;

namespace PiggyBank.Expanses.Features.Categories.CreateCategory;

internal class CreateCategoryCommandHandler(IDbContextFactory<ExpensesDbContext> dbContextFactory)
    : ICommandHandler<CreateCategoryCommand>
{
    private readonly IDbContextFactory<ExpensesDbContext> _dbContextFactory = dbContextFactory;

    public async Task HandleAsync(CreateCategoryCommand command, CancellationToken cancellationToken = default)
    {
        var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        var category = new Category
        {
            Name = command.Name,
            Color = command.Color
        };

        await dbContext.Categories.AddAsync(category, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
