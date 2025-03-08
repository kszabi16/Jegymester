using Jegymester.DataContext.Context;
using Microsoft.OpenApi.Models;
using Jegymester.Services;
using Microsoft.EntityFrameworkCore;



   
var builder = WebApplication.CreateBuilder(args);

 // Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\Local;Database=JegymesterDB;Trusted_Connection=True;TrustServerCertificate=True;"));




builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<ScreeningService>();
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<IUserService, UserService>();



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "JegyMesterApp API", Version = "v1" });
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

 // Configure the HTTP request pipeline.
 if (app.Environment.IsDevelopment())
    {
         app.UseSwagger();
         app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JegyMesterApp API v1"));
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
        
    
