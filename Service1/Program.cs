using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Service1;
using Service1.ApiInteraction;
using Service1.Data;
using Service1.Options;

var config = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
         .Build();

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "AltenarIntership Service1";
});
builder.Services.AddSingleton<IEventData, FakeEvent>();
builder.Services.AddSingleton<IMarketData, FakeMarket>();
builder.Services.AddSingleton<ApiCommunication>();
builder.Services.AddHostedService<ServiceWorker>();
builder.Services.Configure<ApiConnectionOptions>(
    builder.Configuration.GetSection(ApiConnectionOptions.CONNECTION_STRING));
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Logging.AddNLog(config);

var host = builder.Build();
host.Run();