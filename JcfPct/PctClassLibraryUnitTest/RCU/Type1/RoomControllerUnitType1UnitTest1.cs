using NFluent;
using NUnit.Framework;
using PctClassLibrary.Common;
using PctClassLibrary.RCU.Type1;
using PctClassLibrary.SCS;

namespace PctClassLibraryUnitTest.RCU.Type1
{
    public class RcuType1Should
    {
        [Test]
        public void Create_instance_of_correct_type()
        {
            var rcu = new RoomControllerUnit(Definition.TechnologyType.SCS);

            Check.That(rcu).IsInstanceOf<RoomControllerUnit>();
        }

        [Test]
        public void Accept_and_retrieve_correct_type()
        {
            var rcu = new RoomControllerUnit(Definition.TechnologyType.SCS);

            Check.That(rcu.TechnologyType).IsEqualTo(Definition.TechnologyType.SCS);
        }

        [Test]
        public void Add_and_retrieve_a_SCS_device()
        {
            var sn = new SystemName("scsDevice");
            var id = new ScsId("12345678");
            var units = new Unit[0];
            var scsDevice = new PctClassLibrary.SCS.Device(sn, id, units);
            var rcu = new RoomControllerUnit(Definition.TechnologyType.SCS);
            rcu.SCSDevices.AddDevice(scsDevice);

            Check.That(rcu.SCSDevices.Devices[0]).IsInstanceOf<PctClassLibrary.SCS.Device>();
            Check.That(rcu.SCSDevices.Devices[0].SystemName.Value).IsEqualTo("scsDevice");
            Check.That(((PctClassLibrary.SCS.Device)rcu.SCSDevices.Devices[0]).BusId).Equals(id);
            Check.That(((PctClassLibrary.SCS.Device)rcu.SCSDevices.Devices[0]).BusId.Value).IsEqualTo("12345678");
        }
    }
}
