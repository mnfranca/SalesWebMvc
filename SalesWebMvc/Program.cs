using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("SalesWebMvcContext") ?? throw new InvalidOperationException("Connection string 'SalesWebMvcContext' not found."), builder => builder.MigrationsAssembly("SalesWebMvc")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to seeding database
builder.Services.AddScoped<SeedingService>();

// Add services to handle entities
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SalesRecordService>();

var app = builder.Build();

// Globalization and locale
var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = [enUS],
    SupportedUICultures = [enUS]
};
app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    using var serviceScope = app.Services.CreateScope();
    var services = serviceScope.ServiceProvider;
    var seedingService = services.GetRequiredService<SeedingService>();
    seedingService.Seed();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
