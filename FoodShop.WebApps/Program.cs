using FoodShop.Data;
using FoodShop.WebApps.Components;
using FoodShop.WebApps.Middleware;
using FoodShop.WebApps.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register Database service dependency
builder.Services.AddDbContext<FoodShopDbContext>();

// Register helper service dependency
builder.Services.AddScoped<CartServices>();
builder.Services.AddScoped<CurrentUser>();
builder.Services.AddScoped<UserSession>();

// Register Chart-service
builder.Services.AddScoped<ChartServices>();
builder.Services.AddScoped<AdminPageBase>();
builder.Services.AddScoped<CheckRoleServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
