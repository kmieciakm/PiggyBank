using PiggyBank.Expanses.Shared.Models;

namespace PiggyBank.Expanses.Features.Categories;

internal class Category
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public required Color Color { get; set; }
}
