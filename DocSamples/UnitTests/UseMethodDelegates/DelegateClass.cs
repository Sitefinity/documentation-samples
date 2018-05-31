// Documentation articles: https://docs.sitefinity.com/implement-unit-tests-for-sitefinity-cms-functionality

using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp.UnitTests.UseMethodDelegates
{
    public class DelegateClass
    {
        public bool isOperationEnabledDelegate;

        public DelegateClass()
            : this(SystemManager.SystemServices.IsReadOnly)
        {
        }

        public DelegateClass(bool isOperationEnabledDelegate)
        {
            this.isOperationEnabledDelegate = isOperationEnabledDelegate;
        }

        public bool IsDeletionAllowed(ConfigSource saveLocation)
        {
            var canDelete = true;
            var isReadOnlyEnabled = this.isOperationEnabledDelegate;

            if (isReadOnlyEnabled && saveLocation != ConfigSource.Database)
            {
                canDelete = false;
            }

            return canDelete;
        }
    }
}