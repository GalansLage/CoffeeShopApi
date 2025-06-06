using System.Text;
using System.Text.Json.Serialization;
using CoffeeShopApi.Data;
using CoffeeShopApi.Data.Interceptors;
using CoffeeShopApi.Data.Repositories;
using CoffeeShopApi.Domain.StrategyContext;
using CoffeeShopApi.Migrations;
using CoffeeShopApi.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoffeeShopApi", Version = "v1" });

//    // Configuración para soportar JWT en Swagger
//    var securityScheme = new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        Description = "Ingresa el token JWT en el formato: Bearer {token}",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        Scheme = "bearer", // "bearer" debe estar en minúsculas
//        BearerFormat = "JWT",
//        Reference = new OpenApiReference
//        {
//            Type = ReferenceType.SecurityScheme,
//            Id = "Bearer"
//        }
//    };

//    c.AddSecurityDefinition("Bearer", securityScheme);

//    var securityRequirement = new OpenApiSecurityRequirement
//    {
//        { securityScheme, new[] { "Bearer" } }
//    };

//    c.AddSecurityRequirement(securityRequirement);
//});

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("SwaggerPolicy", policy =>
    {
        policy.WithOrigins(
                "https://[tu-servicio].onrender.com",
                "http://[tu-servicio].onrender.com")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

//Context
builder.Services.AddDbContext<CoffeeShopContext>((serviceProvider,options) =>
options
.UseLazyLoadingProxies()
.AddInterceptors(new CachingInterceptor(serviceProvider.GetRequiredService<IMemoryCache>()))
.UseNpgsql(ConnectionStringParser.ParseConnectionString(connectionString) ?? throw new NotImplementedException()));

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

//Dependency Injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ProductStrategyContext>();
builder.Services.AddScoped<OrderStrategyContext>();
builder.Services.AddScoped<ClientStrategyContext>();

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))

    };

});

builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 443;
});

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("/app/data-protection-keys"))
    .SetApplicationName("CoffeeShopApi");

//Build App
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("SwaggerPolicy");

app.UseSwagger(c =>
{
    c.RouteTemplate = "swagger/{documentName}/swagger.json";
    c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
    {
        swaggerDoc.Servers = new List<OpenApiServer>
        {
            new OpenApiServer { Url = $"https://{httpReq.Host.Value}" }
        };
    });
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoffeeShop API v1");
    c.RoutePrefix = "swagger";
    c.ConfigObject.DisplayRequestDuration = true;
});

app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
try {
    MigrationsExtensions.ApplyMigrations(app);
}catch (Exception ex)
{
    Console.WriteLine($"Error aplicando migraciones: {ex.Message}");
}


var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://0.0.0.0:{port}");
