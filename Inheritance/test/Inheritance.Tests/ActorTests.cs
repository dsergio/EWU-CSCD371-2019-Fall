using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void ActorExtensionMethods_Sheldon_Speak()
        {
            // Arrange
            Actor sheldon = new Sheldon();

            // Act

            // Assert
            Assert.AreEqual(sheldon.Speak(), "I am Sheldon");
        }

        [TestMethod]
        public void ActorExtensionMethods_RajWomenPresentTrue_Speak()
        {
            // Arrange
            Actor raj = new Raj();

            // Act
            ((Raj)raj).WomenArePresent = true;

            // Assert
            Assert.AreEqual(raj.Speak(), "mumble mumble");
        }

        [TestMethod]
        public void ActorExtensionMethods_RajWomenPresentFalse_Speak()
        {
            // Arrange
            Actor raj = new Raj();

            // Act
            ((Raj)raj).WomenArePresent = false;

            // Assert
            Assert.AreEqual(raj.Speak(), "I am Raj");
        }

        [TestMethod]
        public void ActorExtensionMethods_Penny_Speak()
        {
            // Arrange
            Actor penny = new Penny();

            // Act

            // Assert
            Assert.AreEqual(penny.Speak(), "I am Penny");
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ActorExtensionMethods_Actor_ArgumentException()
        {
            // Arrange

            // Act

            // Assert
            ActorExtensionMethods.Speak(new Actor());
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void ActorExtensionMethods_Actor_ArgumentNullException()
        {
            // Arrange

            // Act

            // Assert
            ActorExtensionMethods.Speak(null);
        }
    }
}
