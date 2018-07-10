// Documentation articles: https://docs.sitefinity.com/implement-unit-tests-for-sitefinity-cms-functionality

using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp.UnitTests.UseTestableClasses
{
    public class OperationClass
    {
        public bool IsDeletionAllowed(ConfigSource saveLocation)
        {
            var canDelete = true;
            var isReadOnlyEnabled = this.IsReadOnlyEnabled();

            if (isReadOnlyEnabled && saveLocation != ConfigSource.Database)
            {
                canDelete = false;
            }

            return canDelete;
        }

        protected virtual bool IsReadOnlyEnabled()
        {
            return SystemManager.SystemServices.IsReadOnly;
        }
    }
}