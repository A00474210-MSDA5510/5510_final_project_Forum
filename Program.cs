using _5510_final_project_Forum.Data;
using _5510_final_project_Forum.Models;
using _5510_final_project_Forum.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer($"Server=dev.cs.smu.ca;Database=z_wang;User Id=z_wang;Password=winterDETERMINE34;TrustServerCertificate=True;"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IForum, ForumServices>();
builder.Services.AddScoped<IPost, PostService>();
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


