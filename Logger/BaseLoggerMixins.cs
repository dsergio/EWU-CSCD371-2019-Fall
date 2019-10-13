using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Debug(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException();
            } 
            else
            {
                string logMessage;
                if (message is null)
                {
                    logMessage = null;
                } else
                {
                    logMessage = string.Format(message, args);
                }
                baseLogger.Log(LogLevel.Debug, logMessage);
            }

        }

        public static void Error(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException();
            } 
            else
            {
                string logMessage;
                if (message is null)
                {
                    logMessage = null;
                }
                else
                {
                    logMessage = string.Format(message, args);
                }
                baseLogger.Log(LogLevel.Error, logMessage);
            }

        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                string logMessage;
                if (message is null)
                {
                    logMessage = null;
                }
                else
                {
                    logMessage = string.Format(message, args);
                }
                baseLogger.Log(LogLevel.Warning, logMessage);
            }

        }

        public static void Information(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                string logMessage;
                if (message is null)
                {
                    logMessage = null;
                }
                else
                {
                    logMessage = string.Format(message, args);
                }
                baseLogger.Log(LogLevel.Information, logMessage);
            }

        }
    }
}
