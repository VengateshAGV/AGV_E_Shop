
using Application.Contract.Presistence;
using DataConnections.Data;
using DataConnections.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Application.Contract.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Application.Contract.Services.InterFace;
using Shop.ModelArea.Models;
using Stripe;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationContext>(options 
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection")));

builder.Services.AddIdentity<UserID,IdentityRole>(options 
    => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = $"/Identity/Account/Login";
    option.LoginPath = $"/Identity/Account/LogOut";
    option.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(20);
});

builder.Services.AddTransient(typeof(IGenaricRepositry<>), typeof(GenaricRepositry<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddScoped<IUserNameService, UserNameService>();

builder.Services.AddHttpContextAccessor();

#region Seeding Service
static async void UpdateDatabaseAsync(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var service = scope.ServiceProvider;

        try
        {
            var context = service.GetRequiredService<ApplicationContext>();

            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
            }
            await SeedData.SeedDataAsync(context);
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            logger.LogError(ex, "An Error Eccured while migration or sending the database");
        }
    }
}
#endregion


builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var app = builder.Build();

var ServicProvider = app.Services;

await SeedData.SeedRole(ServicProvider);

UpdateDatabaseAsync(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
