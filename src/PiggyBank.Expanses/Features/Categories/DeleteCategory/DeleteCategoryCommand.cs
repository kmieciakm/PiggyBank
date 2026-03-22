using PiggyBank.Expanses.Shared.Commands;

namespace PiggyBank.Expanses.Features.Categories.DeleteCategory;

public class DeleteCategoryCommand : ICommand
{
    public required int CategoryId { get; init; }
}
