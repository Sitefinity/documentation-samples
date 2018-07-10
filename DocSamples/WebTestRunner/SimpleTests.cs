// Documentation article: https://docs.sitefinity.com/tutorial-create-integration-tests-with-sitefinity-web-test-runner

using MbUnit.Framework;

namespace SitefinityWebApp.WebTestRunner
{
    [TestFixture]
    [Description("Some simple tests.")]
    public class SimpleTests
    {
        [Test]
        [Author("Telerik Developer")]
        [Description("A simple test that will pass.")]
        public void PassingTest()
        {
            int expectedValue = 2;

            int actualValue = 1 + 1;

            Assert.AreEqual<int>(expectedValue, actualValue);
        }

        [Test]
        [Author("Telerik Developer")]
        [Description("A simple test that will fail.")]
        public void FailingTest()
        {
            int expectedValue = 2;

            int actualValue = 1 + 1 + 1;

            Assert.AreEqual<int>(expectedValue, actualValue);
        }

        [Test]
        [Author("Telerik Developer")]
        [Description("A simple test that will be ignored. You can run it manually in the Test runner.")]
        [Ignore]
        public void IgnoredTest()
        {
            int expectedValue = 2;

            int actualValue = 1 + 1;

            Assert.AreEqual<int>(expectedValue, actualValue);
        }
    }
}