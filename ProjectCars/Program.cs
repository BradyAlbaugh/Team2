using ProjectCars.Models;
using ProjectCars.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CarsDatabaseSettings>(builder.Configuration.GetSection("CarsDatabase"));

// Add services to the container.
builder.Services.Configure<OwnerDatabaseSettings>(builder.Configuration.GetSection("OwnerDatabase"));

builder.Services.AddSingleton<CarsService>();
builder.Services.AddSingleton <OwnerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
