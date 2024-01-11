using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

builder.Services.AddControllersWithViews();

// Database
var MSSQLdatabase = builder.Configuration.GetConnectionString("SimpleWebsiteDb");
services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(MSSQLdatabase));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
