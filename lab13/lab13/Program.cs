using System;
using Microsoft.Extensions.Logging;



namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", Microsoft.Extensions.Logging.LogLevel.Warning)
                    .AddFilter("System", Microsoft.Extensions.Logging.LogLevel.Warning)
                    .AddFilter("Logging.Program", Microsoft.Extensions.Logging.LogLevel.Debug)
                    .AddConsole()
                    .AddEventLog()
                    .AddDebug();
            });
            Microsoft.Extensions.Logging.ILogger logger = loggerFactory.CreateLogger<Program>();

            logger.LogDebug(1, "The entry point of {0} here.", args);
            logger.LogInformation(2, "The Example of logging information occurred at {0}.", DateTime.UtcNow);
            logger.LogWarning(3, "Example log warning ({0}).", DateTime.UtcNow);
            logger.LogTrace(4, "tracing", DateTime.UtcNow);
            logger.LogError(5, "error", DateTime.UtcNow);
            logger.LogCritical(6, "critical error", DateTime.UtcNow);

            var qwerty = Console.ReadLine();
            logger.LogDebug(1, "The next text was entered by keyBoard:{0}", qwerty);
            
        }
    }
}
