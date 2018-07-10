// Documentation articles: https://docs.sitefinity.com/implement-unit-tests-for-sitefinity-cms-functionality

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Telerik.Sitefinity.Configuration;

namespace SitefinityWebApp.UnitTests.MaintainDecoupledCode
{
    [TestClass]
    public class SitefinityUnitTests
    {
        private SutClass sutInstance;
        private ISystemManagerWrapper systemManager;

        [TestInitialize]
        public void OnTestInitialize()
        {
            this.systemManager = Mock.Create<ISystemManagerWrapper>();
            this.sutInstance = new SutClass(this.systemManager);
        }

        [TestMethod]
        public void IsDeletionAllowed_ReadOnlyEnabled_FileSystemConfigSource_ReturnsFalse()
        {
            Mock.Arrange(() => this.systemManager.IsReadOnlyEnabled()).Returns(true);

            var result = this.sutInstance.IsDeletionAllowed(ConfigSource.FileSystem);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsDeletionAllowed_ReadOnlyDisabled_FileSystemConfigSource_ReturnsTrue()
        {
            Mock.Arrange(() => this.systemManager.IsReadOnlyEnabled()).Returns(false);

            var result = this.sutInstance.IsDeletionAllowed(ConfigSource.FileSystem);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsDeletionAllowed_ReadOnlyEnabled_DatabaseConfigSource_ReturnsTrue()
        {
            Mock.Arrange(() => this.systemManager.IsReadOnlyEnabled()).Returns(true);

            var result = this.sutInstance.IsDeletionAllowed(ConfigSource.Database);

            Assert.IsTrue(result);
        }
    }
}