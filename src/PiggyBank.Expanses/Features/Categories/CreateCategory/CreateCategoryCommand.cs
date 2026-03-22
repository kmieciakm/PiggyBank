using PiggyBank.Expanses.Shared.Commands;
using PiggyBank.Expanses.Shared.Models;

namespace PiggyBank.Expanses.Features.Categories.CreateCategory;

public class CreateCategoryCommand : ICommand
{
    public required string Name { get; set; }
    public required Color Color { get; set; }
}
