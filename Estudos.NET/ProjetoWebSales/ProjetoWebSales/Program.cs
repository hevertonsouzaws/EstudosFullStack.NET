using Microsoft.EntityFrameworkCore;
using ProjetoWebSales.Data;
using ProjetoWebSales.Models;
using ProjetoWebSales.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjetoWebSalesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjetoWebSalesContext") ?? throw new InvalidOperationException("Connection string 'ProjetoWebSalesContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();

var app = builder.Build();

/* Configuração de injeção de dependencia 
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var seedingService = scope.ServiceProvider.GetService<SeedingService>();
        seedingService.Seed();
    }
}
*/

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();

    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
