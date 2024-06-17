using APIKnightMongo.Extensions;
using APIKnightMongo.Models;
using APIKnightMongo.Repositories;
using APIKnightMongo.Repositories.Interfaces;
using APIKnightMongo.Services;
using APIKnightMongo.Services.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


//builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
//builder.Services.Configure<DbConfiguration>(
//    builder.Configuration.GetSection("MongoDbConnection"));

//MongoDB Database
builder.Services.AddDatabaseServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAttributeService, AttributeService>();
builder.Services.AddScoped<IAttributeRepository, AttributeRepository>();
builder.Services.AddScoped<IKnightService, KnightService>();
builder.Services.AddScoped<IKnightRepository, KnightRepository>();
builder.Services.AddControllers();



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
