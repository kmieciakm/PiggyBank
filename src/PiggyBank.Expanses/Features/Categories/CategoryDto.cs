using PiggyBank.Expanses.Shared.Models;

namespace PiggyBank.Expanses.Features.Categories;

public class CategoryDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required Color Color { get; set; }
}
