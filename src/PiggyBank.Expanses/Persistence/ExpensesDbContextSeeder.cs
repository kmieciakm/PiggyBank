using Microsoft.EntityFrameworkCore;
using PiggyBank.Expanses.Features.Categories;
using PiggyBank.Expanses.Shared.Models;

namespace PiggyBank.Expanses.Persistence;

internal class ExpensesDbContextSeeder
{
    public static async Task MigrateAsync(ExpensesDbContext context)
    {
        await context.Database.MigrateAsync();
    }

    public static async Task SeedDataAsync(ExpensesDbContext context)
    {
        if (!await context.Categories.AnyAsync())
        {
            context.Categories.AddRange(
                new Category { Id = 1, Name = "Food", Color = Color.Green },
                new Category { Id = 2, Name = "Transport", Color = Color.Blue },
                new Category { Id = 3, Name = "Entertainment", Color = Color.Green }
            );

            await context.SaveChangesAsync();
        }
    }
}
