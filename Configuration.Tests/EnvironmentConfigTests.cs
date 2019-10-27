using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [DataTestMethod]
        [DataRow("somename", "someval")]
        [DataRow("othername", "other.val")]
        public void EnvironmentConfig_SetConfigValue_GetReturnsCorrectValue(string name, string value)
        {
            // Arrange
            IConfig environmentConfig = new EnvironmentConfig();

            // Act
            environmentConfig.SetConfigValue(name, value);
            environmentConfig.GetConfigValue(name, out string? str);

            // Assert
            Assert.AreEqual(value, str);
        }

        [DataTestMethod]
        [DataRow("some name", "some val")]
        [DataRow("somename ", "someval")]
        [DataRow("= ", " ")]
        [DataRow("somename", "")]
        [DataRow("", "")]
        [DataRow("somename", null)]
        [DataRow(null, "value")]
        [DataRow(null, null)]
        [ExpectedException(typeof(ArgumentException))]
        [ExcludeFromCodeCoverage]
        public void EnvironmentConfig_SetBadNameOrValue_ThrowException(string name, string value)
        {
            // Arrange
            IConfig environmentConfig = new EnvironmentConfig();

            // Act
            environmentConfig.SetConfigValue(name, value);
            environmentConfig.GetConfigValue(name, out string? str);

            // Assert
            Assert.AreEqual(value, str);
        }
    }
}
