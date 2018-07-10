// Documentation articles: https://docs.sitefinity.com/implement-unit-tests-for-sitefinity-cms-functionality

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.Sitefinity.Configuration;

namespace SitefinityWebApp.UnitTests.UseTestableClasses
{
    public class TestableOperationClass : OperationClass
    {
        public bool IsThisOperationEnabled { get; set; }

        protected override bool IsReadOnlyEnabled()
        {
            return IsThisOperationEnabled;
        }

        [TestMethod]
        public void OperationClassIsDeletionAllowed_ReadOnlyEnabled_FileSystemConfigSource_ReturnsFalse()
        {
            var sutInstance = new TestableOperationClass { IsThisOperationEnabled = true };
            var result = sutInstance.IsDeletionAllowed(ConfigSource.FileSystem);

            Assert.IsFalse(result);
        }
    }
}