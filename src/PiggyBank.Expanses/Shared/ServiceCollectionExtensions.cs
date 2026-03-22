using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PiggyBank.Expanses.Features.Categories;
using PiggyBank.Expanses.Features.Categories.CreateCategory;
using PiggyBank.Expanses.Features.Categories.DeleteCategory;
using PiggyBank.Expanses.Features.Categories.GetCategories;
using PiggyBank.Expanses.Persistence;
using PiggyBank.Expanses.Shared.Commands;
using PiggyBank.Expanses.Shared.Queries;

namespace PiggyBank.Expanses.Shared;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExpansesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<ExpensesDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ExpensesDb")));

        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();

        services.AddCategoryFeature();

        return services;
    }

    public static async Task BuildExpansesModule(this IServiceProvider serviceProvider, IHostEnvironment environment)
    {
        using var scope = serviceProvider.CreateScope();

        if (environment.IsDevelopment())
        {
            var context = scope.ServiceProvider.GetRequiredService<ExpensesDbContext>();

            await ExpensesDbContextSeeder.MigrateAsync(context);
            await ExpensesDbContextSeeder.SeedDataAsync(context);
        }
    }

    private static void AddCategoryFeature(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateCategoryCommand>, CreateCategoryCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteCategoryCommand>, DeleteCategoryCommandHandler>();
        
        services.AddScoped<IQueryHandler<GetCategories, IEnumerable<CategoryDto>>, GetCategoriesHandler>();
    }
}
