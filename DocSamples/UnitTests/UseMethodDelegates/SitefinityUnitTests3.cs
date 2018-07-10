// Documentation articles: https://docs.sitefinity.com/implement-unit-tests-for-sitefinity-cms-functionality

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.Sitefinity.Configuration;

namespace SitefinityWebApp.UnitTests.UseMethodDelegates
{
    public class SitefinityUnitTests3
    {
        [TestMethod]
        public void DelegateClassIsDeletionAllowed_ReadOnlyEnabled_FileSystemConfigSource_ReturnsFalse()
        {
            var sutInstance = new DelegateClass { isOperationEnabledDelegate = true };
            var result = sutInstance.IsDeletionAllowed(ConfigSource.FileSystem);

            Assert.IsFalse(result);
        }
    }
}