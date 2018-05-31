// Documentation article: https://docs.sitefinity.com/tutorial-create-integration-tests-with-sitefinity-web-test-runner

using MbUnit.Framework;
using System;
using System.Linq;
using Telerik.Sitefinity.Modules.Libraries;

namespace SitefinityWebApp.WebTestRunner
{
    public class TearDownClass
    {
        [TearDown()]
        public void TearDown(Guid testLibraryId)
        {
            LibrariesManager librariesManager = LibrariesManager.GetManager();

            var library = librariesManager.GetDocumentLibraries().SingleOrDefault(l => l.Id == testLibraryId);

            if (library != null)
            {
                librariesManager.DeleteDocumentLibrary(library);
                librariesManager.SaveChanges();
            }
        }

    }
}