using BookHavenWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Add services required for MVC controllers and views
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    )); // Add Entity Framework Core DbContext with SQL Server as the database provider
builder.Services.AddRazorPages().AddRazorRuntimeCompilation(); // Add Razor Pages with runtime compilation

var app = builder.Build(); // Build the application

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Use custom error page for non-development environments
    app.UseHsts(); // Use HTTP Strict Transport Security (HSTS) middleware
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseStaticFiles(); // Enable serving static files

app.UseRouting(); // Enable routing middleware

app.UseAuthorization(); // Enable authorization middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Define default controller and action

app.Run(); // Start the application
