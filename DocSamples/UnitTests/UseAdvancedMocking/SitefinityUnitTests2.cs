// Documentation articles: https://docs.sitefinity.com/implement-unit-tests-for-sitefinity-cms-functionality

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp.UnitTests.UseAdvancedMocking
{
    public class SitefinityUnitTests2
    {
        public bool StaticIsDeletionAllowed(ConfigSource saveLocation)
        {
            var canDelete = true;
            var isReadOnlyEnabled = SystemManager.SystemServices.IsReadOnly;

            if (isReadOnlyEnabled && saveLocation != ConfigSource.Database)
            {
                canDelete = false;
            }

            return canDelete;
        }

        [TestMethod]
        public void StaticIsDeletionAllowed_ReadOnlyEnabled_FileSystemConfigSource_ReturnsFalse()
        {
            Mock.Arrange(() => SystemManager.SystemServices.IsReadOnly).Returns(true);

            var result = this.StaticIsDeletionAllowed(ConfigSource.FileSystem);

            Assert.IsFalse(result);
        }
    }
}