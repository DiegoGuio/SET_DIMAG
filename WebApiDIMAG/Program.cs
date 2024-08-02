using AccesoDatosDimag.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Crear variable para la cadena de conexi�n
var connectionString = builder.Configuration.GetConnectionString("ConnectionStringsDB_Dimag");
//Registrar un servicio para la conexi�n
builder.Services.AddDbContext<DimagDBContext>(
    options => options.UseSqlServer(connectionString)
);

DimagDBContext.ConnectionString = connectionString;

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
