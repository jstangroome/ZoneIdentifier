using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeAssassin.Tests
{
    [TestClass]
    public class MapUrlToZoneTests
    {
        [TestMethod]
        public void InternetSecurityManager_should_map_Microsoft_to_Internet_zone()
        {
            var zone = InternetSecurityManager.MapUrlToZone(@"http://www.microsoft.com/somepath");
            Assert.AreEqual(UrlZone.Internet, zone);
        }

        [TestMethod]
        public void InternetSecurityManager_should_map_Windows_Task_Manager_to_LocalMachine_zone()
        {
            var zone = InternetSecurityManager.MapUrlToZone(Path.Combine(Environment.SystemDirectory, "taskmgr.exe"));
            Assert.AreEqual(UrlZone.LocalMachine, zone);
        }

    }
}
