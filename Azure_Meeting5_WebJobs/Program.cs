using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostBuilder builder = new HostBuilder();
builder.ConfigureWebJobs(options => {
    options.AddAzureStorageBlobs();
    options.AddAzureStorageQueues();
});
builder.ConfigureLogging((HostBuilderContext context, ILoggingBuilder logBuilder) => {
    logBuilder.AddConsole();
    string appInsightKey = context.Configuration.GetSection("APPINSIGHTS_INSTRUMENTATIONKEY").Value;
    logBuilder.AddApplicationInsightsWebJobs(config =>
    {
        config.InstrumentationKey = appInsightKey;
    });
});
IHost host = builder.Build();
using (host)
    host.Run();