using System.Collections.Generic;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using PctClassLibrary.Common;
using PctClassLibrary.RCU;
using PctClassLibrary.RCU.Type1;
using PctClassLibrary.SCS;

namespace PctClassLibraryUnitTest.RCU
{
    class KeyObjectRcuObjectProxyUnitTestShould
    {
        private RcuController _rcuController;
        private RoomControllerUnit _roomControllerUnit;
        private List<RcuObject> _objects;
        private List<Definition.TechnologyType> _technologyTypes;
        private RcuObject rcuObject1 = new RcuObject("Name100", "100");
        private RcuObject rcuObject2 = new RcuObject("Name200", "200");
        private RcuObject rcuObject3 = new RcuObject("Name300", "300");
        private RcuObject rcuObject4 = new RcuObject("Name400", "400");

        private KeyObject _keyObject1 = new KeyObject("100");
        private KeyObject _keyObject2 = new KeyObject("200");
        private KeyObject _keyObject3 = new KeyObject("300");
        private KeyObject _keyObject4 = new KeyObject("400");

        private Dictionary<KeyObject, RcuObject> _proxyDictionnary;

        [SetUp]
        public void InitTest()
        {
            _objects = new List<RcuObject>() {
                rcuObject1,
                rcuObject1,
                rcuObject1,
                rcuObject1,
                rcuObject2,
                rcuObject3,
                rcuObject4,
                rcuObject4
            };

            _technologyTypes = new List<Definition.TechnologyType>()
            {
                Definition.TechnologyType.SCS,
                Definition.TechnologyType.Mecanical
            };

            _roomControllerUnit = new RoomControllerUnit(_objects, _technologyTypes);
            _rcuController = new RcuController(_roomControllerUnit);

            _proxyDictionnary = new Dictionary<KeyObject, RcuObject>()
            {
                [_keyObject1] = rcuObject1,
                [_keyObject2] = rcuObject2,
                [_keyObject3] = rcuObject3,
                [_keyObject4] = rcuObject4,
            };

        }

        [Test]
        public void Return_rcuObject_200_and_instance_0_when_invoked_with_KeyObject_200()
        {
            var _proxy = new KeyObjectRcuObjectProxy(_proxyDictionnary);
            var x = _proxy.GetObjectInstance(_keyObject2, _rcuController);
            Check.That(x.RcuObject).IsEqualTo(rcuObject2);
            Check.That(x.InstanceNumber).IsEqualTo(0);

        }

        [Test]
        public void Return_rcuObject_null_when_invoked_twice_and_only_1_instance_available()
        {
            var _proxy = new KeyObjectRcuObjectProxy(_proxyDictionnary);
            var x = _proxy.GetObjectInstance(_keyObject2, _rcuController);
            var y = _proxy.GetObjectInstance(_keyObject2, _rcuController);
            Check.That(y).IsNull();
        }

        [Test]
        public void Return_rcuObject_100_and_instance_1_when_invoked_twice_with_KeyObject_100()
        {
            var _proxy = new KeyObjectRcuObjectProxy(_proxyDictionnary);
            var x = _proxy.GetObjectInstance(_keyObject1, _rcuController);
            var y = _proxy.GetObjectInstance(_keyObject1, _rcuController);
            Check.That(y.RcuObject).IsEqualTo(rcuObject1);
            Check.That(y.InstanceNumber).IsEqualTo(1);

        }

    }
}
