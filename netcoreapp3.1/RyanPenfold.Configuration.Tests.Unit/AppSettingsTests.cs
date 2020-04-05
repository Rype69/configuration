using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RyanPenfold.Configuration.Tests.Unit
{
    /// <summary>
    /// Provides tests for the <see cref="AppSettings"/> type.
    /// </summary>
    [TestClass]
    public class AppSettingsTests
    {
        /// <summary>
        /// Tests the <see cref="AppSettings"/> type.
        /// </summary>
        [TestMethod]
        public void GetAppSetting_NameProvided_ReturnsAppSetting()
        {
            // Arrange
            var name = "TestToggleName";
            var expectedResult = "test";

            // Act
            var result = AppSettings.Get(name);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests the <see cref="AppSettings"/> type.
        /// </summary>
        [TestMethod]
        public void GetAppSetting_NameProvided_ReturnsBooleanValue()
        {
            // Arrange
            var name = "TestToggleEnabled";
            var expectedResult = "true";

            // Act
            var result = AppSettings.Get(name);

            // Assert
            Assert.AreEqual(expectedResult, result);
            bool.TryParse(result, out var val);
            Assert.IsTrue(val);
        }

        /// <summary>
        /// Tests the <see cref="AppSettings"/> type.
        /// </summary>
        [ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
        [TestMethod]
        public void GetAppSetting_NoNameProvided_ThrowsException()
        {
            // Arrange
            var name = string.Empty;
            var expectedResult = string.Empty;

            // Act
            var result = AppSettings.Get(name);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}