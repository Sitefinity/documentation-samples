// Documentation articles: https://docs.sitefinity.com/implement-unit-tests-for-sitefinity-cms-functionality

using Telerik.Sitefinity.Configuration;

namespace SitefinityWebApp.UnitTests.MaintainDecoupledCode
{
    public class SutClass
    {
        private readonly ISystemManagerWrapper wrapper;

        public SutClass(ISystemManagerWrapper wrapper)
        {
            this.wrapper = wrapper;
        }

        public bool IsDeletionAllowed(ConfigSource saveLocation)
        {
            var canDelete = true;
            var isReadOnlyEnabled = this.wrapper.IsReadOnlyEnabled();

            if (isReadOnlyEnabled && saveLocation != ConfigSource.Database)
            {
                canDelete = false;
            }

            return canDelete;
        }
    }
}