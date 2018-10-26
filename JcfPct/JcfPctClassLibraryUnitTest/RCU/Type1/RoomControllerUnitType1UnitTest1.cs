using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using PctClassLibrary.RCU.Type1;
using PctClassLibrary;
using PctClassLibrary.Common;
using PctClassLibrary.SCS;

namespace JcfPctClassLibraryUnitTest.RCU.Type1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_RCU_is_of_correct_type()
        {
            var rcu = new RoomControllerUnit(Definition.TechnologyType.SCS);

            Check.That(rcu).IsInstanceOf<RoomControllerUnit>();
            Check.That(rcu.TechnologyType).IsEqualTo(Definition.TechnologyType.SCS);
        }

        [TestMethod]
        public void Test_RCU_can_add_SCS_device()
        {
            var sn = new SystemName("scsDevice");
            var id = new DeviceId("12345678");
            var units = new Unit[0];
            var scsDevice = new PctClassLibrary.SCS.Device(sn, id, units);
            var rcu = new RoomControllerUnit(Definition.TechnologyType.SCS);
            rcu.SCSDevices.AddDevice(scsDevice);
            Check.That(rcu.SCSDevices.Devices[0]).IsInstanceOf<PctClassLibrary.SCS.Device>();
            Check.That(rcu.SCSDevices.Devices[0].SystemName.Value).IsEqualTo("scsDevice");
            Check.That(((PctClassLibrary.SCS.Device)rcu.SCSDevices.Devices[0]).BusID).Equals(id);

            Check.That(((PctClassLibrary.SCS.Device)rcu.SCSDevices.Devices[0]).BusID.Value).IsEqualTo("12345678");
        }
    }
}
