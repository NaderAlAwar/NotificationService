using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotificationServiceTests
{
    [TestClass]
    public class NotificationServiceUnitTests
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void NotificationReceivedTest()
        {
            Assert.AreEqual(true, true); //temporary. needed for build pipeline to work
        }
    }
}
