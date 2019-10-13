using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Debug(null, "");

            // Assert
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Warning_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Warning(null, "");

            // Assert

        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Information(null, "");

            // Assert

        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Error(null, "");

            // Assert

        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }


        [TestMethod]
        public void Debug_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Debug("Message {0} {1}", 42, "hi");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42 hi", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Information_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Information("Message {0} {1} {2}", 42, "hi", 0.1);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42 hi 0.1", logger.LoggedMessages[0].Message);
        }

        

        [DataTestMethod]
        [DataRow(LogLevel.Debug)]
        [DataRow(LogLevel.Error)]
        [DataRow(LogLevel.Warning)]
        [DataRow(LogLevel.Information)]
        public void LogLevel_WithData_LogsMessage(LogLevel logLevel)
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            if (logLevel == LogLevel.Debug)
            {
                logger.Debug("Message {0} {1} {2}", 42, "hi", 0.1);
            } 
            else if (logLevel == LogLevel.Information)
            {
                logger.Information("Message {0} {1} {2}", 42, "hi", 0.1);
            }
            else if (logLevel == LogLevel.Warning)
            {
                logger.Warning("Message {0} {1} {2}", 42, "hi", 0.1);
            }
            else if (logLevel == LogLevel.Error)
            {
                logger.Error("Message {0} {1} {2}", 42, "hi", 0.1);
            }


            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(logLevel, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42 hi 0.1", logger.LoggedMessages[0].Message);
        }

        [DataTestMethod]
        [DataRow(LogLevel.Debug, "")]
        [DataRow(LogLevel.Debug, "a string")]
        [DataRow(LogLevel.Debug, null)]
        [DataRow(LogLevel.Error, "")]
        [DataRow(LogLevel.Error, null)]
        [DataRow(LogLevel.Warning, "")]
        [DataRow(LogLevel.Warning, null)]
        [DataRow(LogLevel.Information, "")]
        [DataRow(LogLevel.Information, null)]
        public void LogLevel_WithStringData_LogsMessage(LogLevel logLevel, string message)
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            if (logLevel == LogLevel.Debug)
            {
                logger.Debug(message);
            }
            else if (logLevel == LogLevel.Information)
            {
                logger.Information(message);
            }
            else if (logLevel == LogLevel.Warning)
            {
                logger.Warning(message);
            }
            else if (logLevel == LogLevel.Error)
            {
                logger.Error(message);
            }

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(logLevel, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual(message, logger.LoggedMessages[0].Message);
        }
    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}
