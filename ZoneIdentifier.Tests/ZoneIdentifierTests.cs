using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeAssassin.Tests
{
    [TestClass]
    public class ZoneIdentifierTests
    {
        private string _zoneTestFileName;
        public string ZoneTestFileName
        {
            get
            {
                if (_zoneTestFileName == null)
                {
                    _zoneTestFileName = Path.GetTempFileName();
                }
                return _zoneTestFileName;
            }
        }

        [TestMethod]
        public void ZoneIdentifier_should_set_zone_to_Internet()
        {
            using (var zid = new ZoneIdentifier(ZoneTestFileName))
                zid.Zone = UrlZone.Internet;

            using (var zid = new ZoneIdentifier(ZoneTestFileName))
                Assert.AreEqual(UrlZone.Internet, zid.Zone);
        }

        [TestMethod]
        public void ZoneIdentifier_should_remove_Internet_zone()
        {
            using (var zid = new ZoneIdentifier(ZoneTestFileName))
                zid.Zone = UrlZone.Internet;

            using (var zid = new ZoneIdentifier(ZoneTestFileName))
                zid.Remove();

            using (var zid = new ZoneIdentifier(ZoneTestFileName))
                Assert.AreEqual(UrlZone.LocalMachine, zid.Zone);
        }

        [TestMethod]
        public void ZoneIdentifier_should_set_zone_to_Intranet()
        {
            using (var zid = new ZoneIdentifier(ZoneTestFileName))
                zid.Zone = UrlZone.Intranet;

            using (var zid = new ZoneIdentifier(ZoneTestFileName))
                Assert.AreEqual(UrlZone.Intranet, zid.Zone);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_zoneTestFileName != null)
            {
                File.Delete(_zoneTestFileName);
                _zoneTestFileName = null;
            }
        }
    }
}