using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Assignment.Tests
{
    [TestClass]
    public class AddressTests
    {
        [DataTestMethod]
        [DataRow("street")]
        [DataRow("city")]
        [DataRow("state")]
        [DataRow("zip")]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void Address_CreateAddressInvalid_ThrowsException(string type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            // Arrange

            // Act
            _ = new Address(
                type == "street" ? null! : "street",
                type == "city" ? null! : "city",
                type == "state" ? null! : "state",
                type == "zip" ? null! : "zip"
                );

            // Assert
        }

    }
}
