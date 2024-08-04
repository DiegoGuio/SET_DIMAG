using AccesoDatosDimag.Context;
using AccesoDatosDimag.Queries;
using LogicaNegocioDimag.BL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Crear variable para la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("ConnectionStringsDB_Dimag");
//Registrar un servicio para la conexión
builder.Services.AddDbContext<DimagDBContext>(
    options => options.UseSqlServer(connectionString)
);

DimagDBContext.ConnectionString = connectionString;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:44381")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddHttpClient();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//LogicaNegocioDimag/BL
builder.Services.AddScoped<UsuariosBL>();
builder.Services.AddScoped<GeografiaBL>();

//AccesoDatosDimag/Queries
builder.Services.AddScoped<UsuariosQueries>();
builder.Services.AddScoped<GeografiaQueries>();

var app = builder.Build();

app.UseRouting();

app.UseCors("AllowSpecificOrigins");

app.UseExceptionHandler("/Home/Error");
app.UseHsts();

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
