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
        [DataRow("somename", "some val")]
        [DataRow("othername", "other.val")]
        public void EnvironmentConfig_SetConfigValue_GetReturnsCorrectValue(string name, string value)
        {
            // Arrange
            IConfig environmentConfig = new EnvironmentConfig();

            // Act
            bool setConfig = environmentConfig.SetConfigValue(name, value);
            bool getConfig = environmentConfig.GetConfigValue(name, out string? str);

            // Assert
            Assert.AreEqual(value, str);
            Assert.IsTrue(setConfig);
            Assert.IsTrue(getConfig);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow("some name", "some val")]
        [DataRow("somename ", "someval")]
        [DataRow("= ", " ")]
        [DataRow("somename", "")]
        [DataRow("", "")]
        [DataRow("somename", null)]
        [DataRow(null, "value")]
        [DataRow(null, null)]
        public void EnvironmentConfig_SetInvalidNameOrValue_ReturnsFalse(string name, string value)
        {
            // Arrange
            IConfig environmentConfig = new EnvironmentConfig();

            // Act
            bool setValueResult = environmentConfig.SetConfigValue(name, value);

            // Assert
            Assert.IsFalse(setValueResult);
        }
    }
}
