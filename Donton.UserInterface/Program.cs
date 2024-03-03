using Donton.BusinessLogic.Contacts;
using Donton.DataAccess.Contexts;
using Donton.DataAccess.DataService;
using Donton.UserInterface.Pages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


builder.Services
.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.LoginPath = "/";
});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/";
    options.SlidingExpiration = true;
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireAll", policy => policy.RequireRole("User", "Admin"));
});

//builder.Services.AddMvc()
//.AddRazorPagesOptions(options =>
//{
//    options.Conventions.AuthorizeFolder("/Contacts", "RequireAll");
//});


#if DEBUG
var connectionString = "DefaultConnection";
var logger_path = "C:\\_STRATOZPHEREDEV\\Logs\\Donton\\logs.txt";
#else
var connectionString = "ProductionConnection";
var logger_path = "D:\\Logs\\logs.txt";
#endif

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File(logger_path, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();



builder.Services.AddDbContext<DontonContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IDataRepository, DataRepository>();
builder.Services.AddTransient<IDataAccessService, DataAccessService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IDependencyAggregate, DependencyAggregate>();
builder.Services.AddTransient<ContactMaintenance>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.Run();
