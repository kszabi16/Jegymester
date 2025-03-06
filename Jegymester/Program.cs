using Jegymester.DataContext.Context;
using Microsoft.EntityFrameworkCore;
using System;


   
var builder = WebApplication.CreateBuilder(args);

 // Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\Local;Database=JegymesterDB;Trusted_Connection=True;TrustServerCertificate=True;"));


builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

 // Configure the HTTP request pipeline.
 if (app.Environment.IsDevelopment())
    {
         app.UseSwagger();
         app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
        
    
