using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Infrastructure.IdentityConfigs;
using Application.Users.Commands;
using Application.Users.Queries;
using MediatR;
using Infrastructure.Services;
using Application.AuthServices;
using Infrastructure.MappingProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Connection String
string connection = builder.Configuration.GetConnectionString("SqlServer");
//string connection = "Server=localhost,1436;Database=MyDatabase;User Id=sa;Password=Aa123456@;TrustServerCertificate=True;";
builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(connection));
builder.Services.AddIdentityService(builder.Configuration);
#endregion
builder.Services.AddMediatR(typeof(RegisterUserCommand).Assembly);
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
