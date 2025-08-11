using Microsoft.OpenApi.Models;
using Rento.Infrastructure.Implemenation.Db;
using Rento.Infrastructure.Implemenation.Repository;
using Rento.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();                  // Optional: remove default providers
builder.Logging.AddConsole();
builder.Logging.AddDebug();                        // Logs to Debug window (for Visual Studio)
builder.Logging.SetMinimumLevel(LogLevel.Debug);   // Set minimum log leve

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RentoDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200") // your Angular dev server
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
    options.RoutePrefix = string.Empty; // Set the Swagger UI at the root URL
});

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
