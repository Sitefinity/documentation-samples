// Documentation articles: https://docs.sitefinity.com/implement-unit-tests-for-sitefinity-cms-functionality

using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp.UnitTests
{
    public class SampleClassUT
    {
        public bool IsDeletionAllowed(ConfigSource saveLocation)
        {
            var canDelete = true;
            var isReadOnlyEnabled = SystemManager.SystemServices.IsReadOnly;

            if (isReadOnlyEnabled && saveLocation != ConfigSource.Database)
            {
                canDelete = false;
            }

            return canDelete;
        }
    }
}