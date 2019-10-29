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

        /// <summary>
        /// Extra Credit
        /// </summary>
        [TestMethod]
        public void EnvironmentConfig_GetValuesByFilter_ReturnsCorrectCount()
        {
            // Extra Credit
            // 

            // Arrange
            EnvironmentConfig environmentConfig = new EnvironmentConfig();
            environmentConfig.SetConfigValue("dsergio_environmentConfigTestValueabcd", "abcd");
            environmentConfig.SetConfigValue("dsergio_environmentConfigTestValue123", "123");

            // Act
            _ = environmentConfig.GetConfigValues("dsergio_environmentConfigTestValue", out Dictionary<string, string?> results);
            bool val1 = results.TryGetValue("dsergio_environmentConfigTestValueabcd", out _);
            bool val2 = results.TryGetValue("dsergio_environmentConfigTestValue123", out _);

            // Assert
            Assert.AreEqual(results.Count, 2);
            Assert.AreEqual(val1, true);
            Assert.AreEqual(val2, true);
        }
    }
}
