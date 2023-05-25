using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
     .ConfigureAppConfiguration(c =>
     {
         c.AddEnvironmentVariables();
     })
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((appBuilder, service) =>
    {
        var configuration = appBuilder.Configuration;

        // Add services to DI container here

    }).Build();

host.Run();