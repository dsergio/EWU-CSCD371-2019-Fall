using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            IConfig mockConfig = new MockConfig();

            // Act
            mockConfig.SetConfigValue("myconfig", "myconfigvalue");
            mockConfig.SetConfigValue("myconfig1", "myconfigvalue1");
            mockConfig.GetConfigValue("myconfig", out string? str);

            // Assert
            Assert.AreEqual("myconfigvalue", str);
            Assert.AreEqual(2, ((MockConfig)mockConfig).ConfigList.Count);
        }
    }
}
