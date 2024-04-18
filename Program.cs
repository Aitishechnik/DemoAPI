using DemoAPI;
using DemoAPI.Controllers;
using DemoAPI.Services;
using DemoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IExtraService, ExtraService>();
builder.Services.AddSingleton<Warehouse>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddSingleton<Garage>();
builder.Services.AddScoped<IGarageService, GarageService>();
builder.Services.AddScoped<IUserLogService, UserLogService>();
builder.Services.AddSingleton<UserLog>();


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
