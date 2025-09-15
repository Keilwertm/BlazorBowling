using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBowling;
using BlazorBowling.Services;

// Single builder instance
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Services
builder.Services.AddScoped<DataRazor>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<DebugStatus>();

#if DEBUG
// Build and run self-checks, then start
var host = builder.Build();
var debugStatus = host.Services.GetRequiredService<DebugStatus>();
try
{
    var checker = new DebugChecker();
    var result = await checker.RunAsync(BowlingScorer.ScoreFromRolls);
    debugStatus.ChecksPassed = result.Passed;
    debugStatus.Message = result.Message;
}
catch (Exception ex)
{
    debugStatus.ChecksPassed = false;
    debugStatus.Message = $"Self-checks failed: {ex.Message}";
}
await host.RunAsync();
#else
await builder.Build().RunAsync();
#endif