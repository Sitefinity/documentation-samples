// Documentation articles: https://docs.sitefinity.com/implement-unit-tests-for-sitefinity-cms-functionality

using Telerik.Sitefinity.Services;

namespace SitefinityWebApp.UnitTests.MaintainDecoupledCode
{
    public interface ISystemManagerWrapper
    {
        bool IsReadOnlyEnabled();
    }

    public class SystemManagerWrapper : ISystemManagerWrapper
    {
        public bool IsReadOnlyEnabled()
        {
            return SystemManager.SystemServices.IsReadOnly;
        }
    }
}