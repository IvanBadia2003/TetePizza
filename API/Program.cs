using TetePizza.Data;
using TetePizza.Business;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IIngredienteService, IngredienteService>();

// Obteniendo la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ServerDB");

builder.Services.AddDbContext<PizzaContext>(options =>
    options.UseSqlServer(connectionString)
    .LogTo(Console.Write, LogLevel.Information));
builder.Services.AddScoped<IPizzaRepository, PizzaEFRepository>();
builder.Services.AddScoped<IIngredienteRepository, IngredienteEFRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()) //DISABLE DUE TO CONTAINERING APP
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
