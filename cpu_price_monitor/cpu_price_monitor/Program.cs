using cpu_price_monitor.Components;
using cpu_price_monitor.Data;
using cpu_price_monitor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<CpuDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CpuDb")));
builder.Services.AddScoped<ICpuService, CpuService>();
builder.Services.AddScoped<IPriceService, PriceService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
