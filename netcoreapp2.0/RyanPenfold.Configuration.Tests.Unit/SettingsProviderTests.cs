using Microsoft.VisualStudio.TestTools.UnitTesting;
using RyanPenfold.Configuration.Tests.Unit.IocContainer;

namespace RyanPenfold.Configuration.Tests.Unit
{
    /// <summary>
    /// Provides unit tests for the <see cref="SettingsProvider{T}"/> type
    /// </summary>
    [TestClass]
    public class SettingsProviderTests
    {
        [TestMethod]
        public void GetOptions_ConfigUpdatedAndAllowReloadsSetToTrue_OptionsUnchanged()
        {
            // Arrange
            SettingsProvider<ConfigurationSettings>.AllowReload = false;
            var originalOptions = SettingsProvider<ConfigurationSettings>.GetSection("IocContainer");

            // Act
            var newOptions = SettingsProvider<ConfigurationSettings>.GetSection("IocContainer");

            // Assert
            Assert.AreEqual(originalOptions, newOptions);
            Assert.IsTrue(originalOptions.Equals(newOptions));
            Assert.AreEqual(originalOptions.Components.Count, newOptions.Components.Count);
        }

        [TestMethod]
        public void GetOptions_ConfigUpdatedAndAllowReloadsSetToTrue_ProvidesNewOptions()
        {
            // Arrange
            SettingsProvider<ConfigurationSettings>.AllowReload = true;
            var originalOptions = SettingsProvider<ConfigurationSettings>.GetSection("IocContainer");
            SettingsProvider<ConfigurationSettings>.ConfigurationFileName = "appsettings2.json";

            // Act
            var newOptions = SettingsProvider<ConfigurationSettings>.GetSection("IocContainer");

            // Assert
            Assert.AreNotEqual(originalOptions, newOptions);
            Assert.IsFalse(originalOptions.Equals(newOptions));
            Assert.AreNotEqual(originalOptions.Components.Count, newOptions.Components.Count);
        }
    }
}
