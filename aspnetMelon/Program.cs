global using aspnetMelon.ViewModels;
using Domain;
using aspnetMelon.Services;
using Infrastructure.Services.Interfaces;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();;
// connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");



//builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<AppDbContext>();;

#region Identity and DbContext Services

builder.Services.AddDomainServices(builder.Configuration);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 5;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.User.RequireUniqueEmail = true;
        options.SignIn.RequireConfirmedAccount = false;
    }).AddRoles<AppRole>()
    .AddEntityFrameworkStores<AppDbContext>();

#endregion

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    //scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureDeleted();
    scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureCreated();
}
app.Run();
