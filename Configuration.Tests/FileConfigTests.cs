using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [DataTestMethod]
        [DataRow("somename", "someval")]
        [DataRow("othername", "other.val")]
        public void FileConfig_SetConfigValue_GetReturnsCorrectValue(string name, string value)
        {
            // Arrange
            FileConfig fileConfig = new FileConfig();

            // Act
            fileConfig.SetConfigValue(name, value);
            fileConfig.GetConfigValue(name, out string? str);

            // Clean up
            fileConfig.DeleteConfigFile();

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
        
        public void FileConfig_SetInvalidNameOrValue_ReturnsFalse(string name, string value)
        {
            // Arrange
            FileConfig fileConfig = new FileConfig();

            // Act
            bool setResult = fileConfig.SetConfigValue(name, value);
            bool getResult = fileConfig.GetConfigValue(name, out string? str);

            // Clean up
            fileConfig.DeleteConfigFile();

            // Assert
            Assert.IsFalse(setResult);
            Assert.IsFalse(getResult);
            Assert.IsNull(str);
        }

        [DataTestMethod]
        [DataRow("name")]
        [DataRow("na=me")]
        public void FileConfig_NoFileGetConfigByName_ReturnsNull(string name)
        {
            // Arrange
            FileConfig fileConfig = new FileConfig();
            fileConfig.DeleteConfigFile();

            // Act
            fileConfig.GetConfigValue(name, out string? str);

            // Assert
            Assert.IsNull(str);
        }

        /// <summary>
        /// Extra Credit
        /// </summary>
        [TestMethod]
        public void FileConfig_GetValuesByFilter_ReturnsCorrectCount()
        {
            // Extra Credit
            // 

            // Arrange
            FileConfig fileConfig = new FileConfig();
            fileConfig.SetConfigValue("dsergio_environmentConfigTestValueabcd", "abcd");
            fileConfig.SetConfigValue("dsergio_environmentConfigTestValue123", "123");

            // Act
            _ = fileConfig.GetConfigValues("dsergio_environmentConfigTestValue", out Dictionary<string, string?> results);
            bool val1 = results.TryGetValue("dsergio_environmentConfigTestValueabcd", out _);
            bool val2 = results.TryGetValue("dsergio_environmentConfigTestValue123", out _);

            // Clean up
            fileConfig.DeleteConfigFile();

            // Assert
            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(val1);
            Assert.IsTrue(val2);
        }
    }
}
