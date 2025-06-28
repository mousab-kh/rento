using AutoMapper;
using Microsoft.OpenApi.Models;
using Rento.Entities;
using Rento.Infrastructure.Implemenation.Db;
using Rento.Infrastructure.Implemenation.Repository;
using Rento.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RentoDbContext>();
builder.Services.AddScoped<IRepository<Branch>,BranchRepository>();
builder.Services.AddScoped<IRepository<BranchWorkingHour>, BranchWorkingHoursRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMvc();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
    options.RoutePrefix = string.Empty; // Set the Swagger UI at the root URL
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
