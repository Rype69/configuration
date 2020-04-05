using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RyanPenfold.Configuration.Tests.Unit
{
    /// <summary>
    /// Provides tests for the <see cref="ConnectionStrings"/> type.
    /// </summary>
    [TestClass]
    public class ConnectionStringsTests
    {
        /// <summary>
        /// Tests the <see cref="ConnectionStrings"/> type.
        /// </summary>
        [TestMethod]
        public void GetConnectionString_NameProvided_ReturnsConnectionString()
        {
            // Arrange
            var name = "TestDb";
            var expectedResult = "Server=.;Database=TestDb;Trusted_Connection=true;";

            // Act
            var result = ConnectionStrings.Get(name);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests the <see cref="ConnectionStrings"/> type.
        /// </summary>
        [ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
        [TestMethod]
        public void GetConnectionString_NoNameProvided_ThrowsException()
        {
            // Arrange
            var name = string.Empty;
            var expectedResult = string.Empty;

            // Act
            var result = ConnectionStrings.Get(name);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
