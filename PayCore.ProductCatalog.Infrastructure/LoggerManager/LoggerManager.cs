
using NLog;
using PayCore.ProductCatalog.Application.Interfaces.Log;
using System;

namespace PayCore.ProductCatalog.Infrastructure
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerManager() { }
        public void LogDebug(Exception ex,string message)
        {
            logger.Debug(ex,message);
        }
        public void LogError(Exception ex,string message)
        {
            logger.Error(ex,message);
        }

        public void LogInfo(Exception ex,string message)
        {
            logger.Info(ex,message);
        }
        public void LogWarn(Exception ex,string message)
        {
            logger.Warn(ex,message);
        }
    }
}
