using EnglishWords.Context;
using EnglishWords.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>();



var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        context.Database.Migrate();
        DataSeed dataSeed = new DataSeed(context);
        dataSeed.CreateUser();
        dataSeed.CreateWords();
        dataSeed.CreateWordsLearned();

    }
    catch (Exception ex)
    {
        throw new Exception(ex.ToString());
    }
}

app.UseCors(builder =>
    builder.WithOrigins("http://localhost:5173") 
           .AllowAnyHeader()
           .AllowAnyMethod() 
           .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

