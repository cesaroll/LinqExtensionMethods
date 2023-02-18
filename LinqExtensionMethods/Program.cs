// See https://aka.ms/new-console-template for more information

using LinqExtensionMethods;
using Microsoft.Extensions.Configuration;
using LinqExtensionMethods.db;
using LinqExtensionMethods.db.Repositories;
using LinqExtensionMethods.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


var config = new ConfigurationBuilder()
	.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
	.Build();

var services = new ServiceCollection();

services.AddLogging(builder =>
{
	builder.AddConsole();
});

services.AddDbContext<PostgresContext>(cfg =>
{
	cfg.UseNpgsql(config.GetConnectionString("DefaultConnection"))
		.EnableSensitiveDataLogging();
});

services.AddSingleton<Application>();
services.AddScoped<CustomersRepository>();
services.AddScoped<CustomersService>();
services.AddSingleton<SedDb>();

var serviceProvider = services.BuildServiceProvider();

var application = serviceProvider.GetRequiredService<Application>();

await application.RunAsync();