using Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerServices
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerManager()
        {

        }

        public void Info(string msg)
        {
            logger.Info(msg);
        }

        public void Warning(string msg)
        {
            logger.Warn(msg);
        }

        public void Debug(string msg)
        {
            logger.Debug(msg);
        }

        public void Error(string msg)
        {
            logger.Error(msg);
        }
    }
}
