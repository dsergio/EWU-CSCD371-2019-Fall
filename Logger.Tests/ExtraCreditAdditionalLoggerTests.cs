using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Tests
{
    [TestClass]
    public class ExtraCreditAdditionalLoggerTests
    {

        [DataTestMethod]
        [DataRow(LogLevel.Error, "test message")]
        [DataRow(LogLevel.Error, null)]
        [DataRow(LogLevel.Debug, "test message")]
        [DataRow(LogLevel.Debug, null)]
        [DataRow(LogLevel.Information, "test message")]
        [DataRow(LogLevel.Warning, "test message")]
        public void ExtraCreditAdditionalLogger_Log(LogLevel logLevel, string message)
        {
            // Arrange
            LogFactory logFactory = new LogFactory();
            BaseLogger extraCreditAdditionalLogger = logFactory.CreateExtraCreditAdditionalLogger(nameof(ExtraCreditAdditionalLoggerTests));

            // Act
            extraCreditAdditionalLogger.Log(logLevel, message);

            // Assert
            Assert.IsNotNull(extraCreditAdditionalLogger);
        }

        [TestMethod]
        public void Information_ExtraCreditLogger_WithData_LogsMessage()
        {
            // Arrange
            var logFactory = new LogFactory();
            ExtraCreditAddtionalLogger logger = (ExtraCreditAddtionalLogger)logFactory.CreateExtraCreditAdditionalLogger(nameof(ExtraCreditAdditionalLoggerTests));

            // Act
            logger.Information("Message {0} {1} {2}", 42, "hi", 0.1);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42 hi 0.1", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Warning_ExtraCreditLogger_WithData_LogsMessage()
        {
            // Arrange
            var logFactory = new LogFactory();
            ExtraCreditAddtionalLogger logger = (ExtraCreditAddtionalLogger)logFactory.CreateExtraCreditAdditionalLogger(nameof(ExtraCreditAdditionalLoggerTests));

            // Act
            logger.Warning("Message {0} {1} {2}", 42, "hi", 0.1);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42 hi 0.1", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Debug_ExtraCreditLogger_WithData_LogsMessage()
        {
            // Arrange
            var logFactory = new LogFactory();
            ExtraCreditAddtionalLogger logger = (ExtraCreditAddtionalLogger)logFactory.CreateExtraCreditAdditionalLogger(nameof(ExtraCreditAdditionalLoggerTests));

            // Act
            logger.Debug("Message {0} {1} {2}", 42, "hi", 0.1);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42 hi 0.1", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Error_ExtraCreditLogger_WithData_LogsMessage()
        {
            // Arrange
            var logFactory = new LogFactory();
            ExtraCreditAddtionalLogger logger = (ExtraCreditAddtionalLogger)logFactory.CreateExtraCreditAdditionalLogger(nameof(ExtraCreditAdditionalLoggerTests));

            // Act
            logger.Error("Message {0} {1} {2}", 42, "hi", 0.1);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42 hi 0.1", logger.LoggedMessages[0].Message);
        }
    }
}
