using PiggyBank.Expanses.Features.Categories;

namespace PiggyBank.Expanses.Features.Expanses;

internal class Expanse
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public required decimal Amount { get; set; }
    public required Category Category { get; set; }
    public required DateTime Date { get; set; }
    public required string Description { get; set; }
}