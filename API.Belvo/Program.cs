using System.Globalization;
using API.Belvo.Persistence;
using API.Belvo.Services;
using API.Belvo.Utils;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Workcube.JwtAutentication;

var builder = WebApplication.CreateBuilder(args);

// M�s informaci�n sobre la configuraci�n de Swagger/OpenAPI en https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyecta las dependencias de JWT.
builder.Services.AddCustomJwtAuthentication();

// Determina la cadena de conexi�n de la base de datos seg�n el entorno.
var connectionStringName = builder.Environment.IsProduction() ? "Production" : "Development";
var connectionString = builder.Configuration.GetConnectionString(connectionStringName);
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));

// Registra servicios en el contenedor de inyecci�n de dependencias.
builder.Services.AddScoped<BelvoService, BelvoService>();
builder.Services.AddScoped<CuentasService, CuentasService>();

// Configura AutoMapper.
builder.Services.AddAutoMapper(typeof(Program));
var mapperConfig = new MapperConfiguration(m => m.AddProfile(new MappingProfile()));

// Agrega servicios al contenedor.
builder.Services.AddControllers();

var app = builder.Build();

// Configura la cultura predeterminada para el manejo de formatos de fecha y n�meros.
var cultureInfo = new CultureInfo("es-MX");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Configura enrutamiento para controladores.
app.MapControllers();

// Configura la pol�tica CORS para permitir solicitudes desde cualquier origen.
app.UseCors(c => c.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

// Configura el canal de peticiones HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Inicia la aplicaci�n.
app.Run();
