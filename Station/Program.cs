using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Station.BusinessLogic.Implementations;
using Station.BusinessLogic.Interfaces;
using Station.Common;
using Station.Models;

//static void ConfigurationBuild(IConfigurationBuilder builder)
//{
//    builder.SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
//    .AddEnvironmentVariables();
//}


//var builder = new ConfigurationBuilder();
//ConfigurationBuild(builder);
//builder.SetBasePath(Directory.GetCurrentDirectory());
//builder.AddJsonFile("appsettings.json");
//var config = builder.Build();
//string connection = config.GetConnectionString("DefaultConnection");

//var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MapperProfile()));
//mappingConfig.AssertConfigurationIsValid();
//IMapper mapper = mappingConfig.CreateMapper();


//var host = Host.CreateDefaultBuilder()
//.ConfigureServices((context, services) =>
//{
//    services.AddTransient<IRefuellingService, RefuellingService>();
//    services.AddControllers();
//    services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
//    services.AddSingleton(mapper);
//})
//.Build();

//var service = ActivatorUtilities.CreateInstance<RefuellingService>(host.Services);
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MapperProfile()));
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddControllers();
builder.Services.AddTransient<IRefuellingService, RefuellingService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();