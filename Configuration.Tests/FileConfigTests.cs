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
            IConfig fileConfig = new FileConfig();

            // Act
            fileConfig.SetConfigValue(name, value);
            fileConfig.GetConfigValue(name, out string? str);

            // Clean up
            FileConfig.DeleteConfigFile();

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
        public void FileConfig_SetBadNameOrValue_ThrowException(string name, string value)
        {
            // Arrange
            IConfig fileConfig = new FileConfig();

            // Act
            fileConfig.SetConfigValue(name, value);
            fileConfig.GetConfigValue(name, out string? str);

            // Clean up
            FileConfig.DeleteConfigFile();

            // Assert
            Assert.AreEqual(value, str);
        }

        [DataTestMethod]
        [DataRow("name")]
        [DataRow("na=me")]
        public void FileConfig_NoFileGetConfigByName_ReturnsNull(string name)
        {
            // Arrange
            IConfig fileConfig = new FileConfig();

            // Act
            fileConfig.GetConfigValue(name, out string? str);

            // Clean up
            FileConfig.DeleteConfigFile();

            // Assert
            Assert.IsNull(str);
        }
    }
}
