using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Connection String
string connection = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connection));
#endregion

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
