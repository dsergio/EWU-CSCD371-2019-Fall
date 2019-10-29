using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class MockConfigTests
    {
        [TestMethod]
        public void MockConfig_SetConfigValue_GetReturnsCorrectValue()
        {
            // Arrange
            MockConfig mockConfig = new MockConfig();

            // Act
            mockConfig.SetConfigValue("myconfig", "myconfigvalue");
            mockConfig.SetConfigValue("myconfig1", "myconfigvalue1");
            mockConfig.GetConfigValue("myconfig", out string? str);

            // Assert
            Assert.AreEqual("myconfigvalue", str);
            Assert.AreEqual(2, mockConfig.ConfigList.Count);
        }

        [TestMethod]
        public void MockConfig_OverwriteValue_NewValueReturned()
        {
            // Arrange
            MockConfig mockConfig = new MockConfig();

            // Act
            bool setResult1 = mockConfig.SetConfigValue("key1", "firstvalue");
            bool setResult2 = mockConfig.SetConfigValue("key1", "secondvalue");
            bool getResult = mockConfig.GetConfigValue("key1", out string? str);

            // Assert
            Assert.IsTrue(setResult1);
            Assert.IsTrue(setResult2);
            Assert.IsNotNull(str);
            Assert.AreEqual(str, "secondvalue");
            Assert.IsTrue(getResult);
        }

        [DataTestMethod]
        [DataRow("config1", "config1value")]
        public void MockConfig_SetConfigValidInput_ReturnsTrue(string name, string value)
        {
            // Arrange
            MockConfig mockConfig = new MockConfig();

            // Act
            bool setResult = mockConfig.SetConfigValue(name, value);
            bool getResult = mockConfig.GetConfigValue(name, out _);


            // Assert
            Assert.IsTrue(setResult);
            Assert.IsTrue(getResult);
        }

        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("notnull", null)]
        [DataRow(null, "notnull")]
        public void MockConfig_SetConfigInvalidInput_ReturnsFalse(string name, string value)
        {
            // Arrange
            MockConfig mockConfig = new MockConfig();

            // Act
            bool result = mockConfig.SetConfigValue(name, value);

            // Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("not null")]
        public void MockConfig_GetConfigValueInvalidInput_ReturnsFalse(string name)
        {
            // Arrange
            MockConfig mockConfig = new MockConfig();

            // Act
            bool result = mockConfig.GetConfigValue(name, out _);

            // Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("notnull")]
        public void MockConfig_GetConfigValuesInvalidInput_ReturnsFalse(string name)
        {
            // Arrange
            MockConfig mockConfig = new MockConfig();

            // Act
            bool result = mockConfig.GetConfigValues(name, out _);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Extra Credit
        /// </summary>
        [TestMethod]
        public void MockConfig_GetValuesByFilter_ReturnsCorrectCount()
        {
            // Extra Credit
            // 

            // Arrange
            MockConfig mockConfig = new MockConfig();
            mockConfig.SetConfigValue("dsergio_environmentConfigTestValueabcd", "abcd");
            mockConfig.SetConfigValue("dsergio_environmentConfigTestValue123", "123");

            // Act
            _ = mockConfig.GetConfigValues("dsergio_environmentConfigTestValue", out Dictionary<string, string?> results);
            bool val1 = results.TryGetValue("dsergio_environmentConfigTestValueabcd", out _);
            bool val2 = results.TryGetValue("dsergio_environmentConfigTestValue123", out _);

            // Assert
            Assert.AreEqual(results.Count, 2);
            Assert.AreEqual(val1, true);
            Assert.AreEqual(val2, true);
        }
    }
}
