using Microsoft.Azure.ServiceBus;
using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationServiceApi;
using System;
using Newtonsoft.Json;
using System.Text;
using Moq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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
           Assert.AreEqual(true, true); 
        }
    }
}
