
using Microsoft.Extensions.Logging;

namespace CodeAssistant.Debugging
{
    public static class LoggingFactory
    {
        private static readonly ILoggerFactory _loggerFactory = 
            LoggerFactory.Create(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Debug)
            .AddConsole();
        });
        public static ILogger<T> CreateLogger<T>() =>
            _loggerFactory.CreateLogger<T>();
    }
}
