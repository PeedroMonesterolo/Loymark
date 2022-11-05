using Loymark.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using WEBAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mapper
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
// Inicializa configuracion de CORS
builder.Services.ConfigureCors();
// Inicializa las inyecciones de dependencia
builder.Services.AddAplicacionServices();
// Inicializa configuracion de VALIDACION DE ERRORES
builder.Services.AddValidationErrors();
// Conexion a BD
builder.Services.AddDbContext<LoymarkContext>(optionsAction =>
{
    // Toma valor de BD de appsettings
    optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("loymark"));
    optionsAction.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});



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
