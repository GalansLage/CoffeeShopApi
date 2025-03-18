using System.Text.Json.Serialization;
using CoffeeShopApi.Data;
using CoffeeShopApi.Data.Interceptors;
using CoffeeShopApi.Data.Repositories;
using CoffeeShopApi.Domain;
using CoffeeShopApi.Domain.StrategyContext;
using CoffeeShopApi.Utils.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Context
builder.Services.AddDbContext<CoffeeShopContext>((serviceProvider,options) =>
options
.UseLazyLoadingProxies()
.AddInterceptors(new CachingInterceptor(serviceProvider.GetRequiredService<IMemoryCache>()))
.UseNpgsql(builder.Configuration.GetConnectionString("CoffeeShopConnection") ?? throw new NotImplementedException()));

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


//Build App
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
