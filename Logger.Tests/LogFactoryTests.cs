using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [DataTestMethod]
        [DataRow("path")]
        public void LogFactory_CreateLogger_FileLoggerClassName(string path)
        {
            // Arrange
            LogFactory logFactory = new LogFactory();

            // Act
            logFactory.ConfigureFileLogger(path);
            BaseLogger fileLogger = logFactory.CreateLogger("FileLogger");

            // Assert
            Assert.IsTrue(fileLogger.ClassName == "FileLogger");
        }

        [TestMethod]
        public void LogFactory_CreateLogger_LoggerDoesntExist()
        {
            // Arrange
            LogFactory logFactory = new LogFactory();

            // Act
            BaseLogger otherLogger = logFactory.CreateLogger("otherLogger");

            // Assert
            Assert.IsNull(otherLogger);
        }
    }
}
