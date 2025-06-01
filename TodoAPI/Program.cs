using TodoAPI.Models;
using TodoAPI.AppDataContext;
using TodoAPI.Middleware;
using Microsoft.AspNetCore.OpenApi;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.Configure<DbSetting>(builder.Configuration.GetSection("DbSetting")); 
builder.Services.AddSingleton<TodoDbContext>();

var app = builder.Build();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddLogging();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

{
    using var scope = app.Services.CreateScope(); 
    var context = scope.ServiceProvider; 
} 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();