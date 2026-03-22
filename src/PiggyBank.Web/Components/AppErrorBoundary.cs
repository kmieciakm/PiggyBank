using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace PiggyBank.Web.Components;

public class AppErrorBoundary : ErrorBoundary
{
    [Inject]
    ILogger<AppErrorBoundary> Logger { get; set; } = default!;

    [Inject]
    NavigationManager NavigationManager { get; set; } = default!;

    protected override Task OnErrorAsync(Exception ex)
    {
        Logger.LogError(ex, "Unexpected application error.");

        NavigationManager.NavigateTo("/error", true);

        return Task.CompletedTask;
    }
}
