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
            BaseLogger fileLogger = logFactory.CreateLogger("FileLogger");

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
            BaseLogger fileLogger = logFactory.CreateLogger("FileLogger");

            // Assert
            Assert.IsNotNull(fileLogger);

        }

    }
}
