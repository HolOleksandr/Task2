using BookLibrary.Configurations;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterDependencies();
builder.Services.ConfigureMapping();
builder.Services.ConfigureValidators();


var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .WriteTo.Console(new JsonFormatter())
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseCors("CorsDefault");
app.UseAuthorization();
app.MapControllers();
app.Run();
