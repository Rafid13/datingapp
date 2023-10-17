using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();

var app = builder.Build();

// app.UseHttpsRedirection();

// app.UseAuthorization();

// Configure HTTP request pipeline

app.UseCors(builder => builder.AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.MapControllers();

app.Run();
