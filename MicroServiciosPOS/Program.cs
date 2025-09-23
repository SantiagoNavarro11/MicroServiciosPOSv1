using MicroServiciosPOS.Middlewares;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Definir la política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()  // Permite cualquier origen
              .AllowAnyMethod()  // Permite cualquier método (GET, POST, etc.)
              .AllowAnyHeader(); // Permite cualquier encabezado
    });
});
builder.Services.AddScoped<GloblalExceptionHandlingMiddleware>();
builder.Services.AddAuthorization(); // ? Agregado
builder.Services.AddControllers();
// Automapper - registro de mapeos.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configuración Swagger.
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API POS",
        Version = "v1"
    });

    // Configuración para usar un Bearer Token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Description = "Ingresa el token en el siguiente formato: Bearer {tu token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle.
builder.Services.AddEndpointsApiExplorer();

// Configuración Singleton.
builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



builder.Logging.AddApplicationInsights(
    configureTelemetryConfiguration: (config) =>
        config.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"],
    configureApplicationInsightsLoggerOptions: (options) => { }
);

// Configurar filtros de logging
builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Information);

// Inyección de dependencias.
builder.Services.InyeccionDependencias();

// Configuración del Contexto.
builder.Services.AgregarContextoBD(builder.Configuration);

// Agregar HttpClient para solicitudes internas.
builder.Services.AddHttpClient();

// app => Define una clase que proporciona los mecanismos para configurar la solicitud de una aplicación.
var app = builder.Build();

// Configurar la zona horaria predeterminada a Colombia (SA Pacific Standard Time)
var colombiaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
TimeZoneInfo.ClearCachedData(); // Limpia la caché de zonas horarias, opcional
app.Services.GetService<IServiceProvider>().GetService<ILogger<Program>>()
    ?.LogInformation($"Zona horaria configurada: {colombiaTimeZone.DisplayName}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configuración de los Cors.
app.UseCors("AllowAllOrigins");

// Configuración Swagger.
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "POS WEB API v1");
    c.RoutePrefix = "swagger"; // Cambiado aquí
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GloblalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();