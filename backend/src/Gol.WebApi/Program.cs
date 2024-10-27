using Gol.WebApi.Infrastructure.Context;
using Gol.WebApi.Infrastructure.Repositories;
using Gol.WebApi.Infrastructure.Repositories.Interfaces;
using Gol.WebApi.Services;
using Gol.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services
    .AddScoped<ICarService, CarService>()
    .AddScoped<ITruckService, TruckService>()
    .AddScoped<IVehicleService, VehicleService>()
    .AddScoped<IRevisionService, RevisionService>()
    .AddScoped<IVehicleRepository, VehicleRepository>()
    .AddScoped<ICarRepository, CarRepository>()
    .AddScoped<ITruckRepository, TruckRepository>()
    .AddScoped<IRevisionRepository, RevisionRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if(connectionString is null)
    throw new NullReferenceException("DefaultConnection is null");

builder.Services
    .AddDbContext<GolContext>(options =>
        options.UseSqlServer(connectionString, config =>
        {
            config.EnableRetryOnFailure();
            config.UseRelationalNulls();
        }));

builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GolContext>();
    await db.Database.MigrateAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
