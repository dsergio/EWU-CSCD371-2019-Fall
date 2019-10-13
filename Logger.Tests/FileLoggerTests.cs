using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [DataRow(LogLevel.Debug, "test message")]
        public void FileLogger_Log(LogLevel logLevel, string message)
        {
            // Arrange
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger("logFile123");
            BaseLogger fileLogger = logFactory.CreateLogger(nameof(FileLoggerTests));

            // Act
            fileLogger.Log(logLevel, message);

            // Assert
            Assert.IsNotNull(fileLogger);
        }

    }
}
