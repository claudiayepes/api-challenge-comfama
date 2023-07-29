using Jikan.WebApi.Domain;
using Jikan.WebApi.Entities;
using Jikan.WebApi.Gateways;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servicios de la aplicación
builder.Services.AddScoped<IJikanService, JikanService>();
builder.Services.AddScoped<IGetSeriesByDescriptionInteractor, GetSeriesByDescriptionInteractor>();
builder.Services.AddHttpClient();

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
