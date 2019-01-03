using System;
using System.Collections.Generic;
using NFluent;
using NUnit.Framework;
using PctClassLibrary.Common;
using PctClassLibrary.RCU;
using PctClassLibrary.RCU.Type1;
using PctClassLibrary.SCS;

namespace PctClassLibraryUnitTest.RCU
{
    class RcuControllerShould
    {
        private RcuController _rcuController;
        private RoomControllerUnit _roomControllerUnit;
        private List<RcuFunctionnalObject> _objects;
        private List<Definition.TechnologyType> _technologyTypes;
        private RcuFunctionnalObject _rcuFunctionnalObject1 = new RcuFunctionnalObject("Name100", "100");
        private RcuFunctionnalObject _rcuFunctionnalObject2 = new RcuFunctionnalObject("Name200", "200");
        private RcuFunctionnalObject _rcuFunctionnalObject3 = new RcuFunctionnalObject("Name300", "300");
        private RcuFunctionnalObject _rcuFunctionnalObject4 = new RcuFunctionnalObject("Name400", "400");

        private KeyObject _keyObject1 = new KeyObject("100");
        private KeyObject _keyObject2 = new KeyObject("200");
        private KeyObject _keyObject3 = new KeyObject("300");
        private KeyObject _keyObject4 = new KeyObject("400");


        [SetUp]
        public void InitTest()
        {
            _objects = new List<RcuFunctionnalObject>() {
                _rcuFunctionnalObject1,
                _rcuFunctionnalObject1,
                _rcuFunctionnalObject1,
                _rcuFunctionnalObject1,
                _rcuFunctionnalObject2,
                _rcuFunctionnalObject3,
                _rcuFunctionnalObject4,
                _rcuFunctionnalObject4
            };

            _technologyTypes = new List<Definition.TechnologyType>()
            {
                Definition.TechnologyType.SCS,
                Definition.TechnologyType.KNX
            };

            _roomControllerUnit = new RoomControllerUnit(_objects, _technologyTypes);
            _rcuController = new RcuController(_roomControllerUnit);
        }

        [Test]
        public void Create_object_of_type_RCUController()
        {
            Check.That(_rcuController).IsInstanceOf<RcuController>();
        }

        [Test]
        public void Throw_ArgumentException_when_add_device_with_unknow_technology()
        {
            var sn = new SystemName("Command5");
            var mecaDevice = new PctClassLibrary.Mechanical.SingleInput(sn);
            Check.ThatCode(() => _rcuController.AddDevice(mecaDevice)).Throws<ArgumentException>();
        }

        [Test]
        public void Add_and_retrieve_a_SCS_device()
        {
            var sn = new SystemName("Command5");
            var id = new ScsId("12345678");
            var units = new Unit[0];
            var scsDevice = new PctClassLibrary.SCS.Device(sn, id, units);
            _rcuController.AddDevice(scsDevice);

            Check.That(_rcuController.GetDevices4Technology(Definition.TechnologyType.SCS).Devices[0]).IsInstanceOf<PctClassLibrary.SCS.Device>();
            Check.That(_rcuController.GetDevices4Technology(Definition.TechnologyType.SCS).Devices[0].SystemName.Value).IsEqualTo("Command5");
            Check.That(((PctClassLibrary.SCS.Device)_rcuController.GetDevices4Technology(Definition.TechnologyType.SCS).Devices[0]).BusId).Equals(id);
            Check.That(((PctClassLibrary.SCS.Device)_rcuController.GetDevices4Technology(Definition.TechnologyType.SCS).Devices[0]).BusId.Value).IsEqualTo("12345678");
        }
    }
}
