using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        [TestMethod]
        public void CreateLogger_NotConfigured_ReturnsNull()
        {
            // Arrange
            LogFactory logFactory = new LogFactory();

            // Act
            BaseLogger fileLogger = logFactory.CreateLogger(nameof(FileLoggerTests));

            // Assert
            Assert.IsNull(fileLogger);

        }

        [TestMethod]
        public void CreateLogger_Configured_ReturnsNotNull()
        {
            // Arrange
            LogFactory logFactory = new LogFactory();

            // Act
            logFactory.ConfigureFileLogger("logFile123");
            BaseLogger fileLogger = logFactory.CreateLogger(nameof(FileLoggerTests));

            // Assert
            Assert.IsNotNull(fileLogger);

        }

        [DataTestMethod]
        [DataRow(LogLevel.Debug, "test message", "logFile123")]
        public void FileLogger_Log_LogFileExists(LogLevel logLevel, string message, string path)
        {
            // Arrange
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(path);
            BaseLogger fileLogger = logFactory.CreateLogger(nameof(FileLoggerTests));

            // Act
            fileLogger.Log(logLevel, message);
            bool fileExists = File.Exists(path);

            // Assert
            Assert.IsTrue(fileExists);

        }

    }
}
