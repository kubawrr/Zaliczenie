using PCParts.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Data;
var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IComputerServicMemory, ComputerServiceMemory>();
builder.Services.AddDbContext<Data.AppDbContext>();
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Data.AppDbContext>();
builder.Services.AddScoped<IComputerService, ComputerService>();
//builder.Services.AddSingleton<IComputerService, ComputerService>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

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

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
