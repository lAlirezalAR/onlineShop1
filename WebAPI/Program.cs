using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Infrastructure.IdentityConfigs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Connection String
string connection = builder.Configuration.GetConnectionString("SqlServer");
//string connection = "Server=localhost,1436;Database=MyDatabase;User Id=sa;Password=Aa123456@;TrustServerCertificate=True;";
builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(connection));
builder.Services.AddIdentityService(builder.Configuration);

builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    option.LoginPath = "Account/login";
    option.AccessDeniedPath = "Account/AccessDenied";
    option.SlidingExpiration = true;
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
