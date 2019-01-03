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
    class KeyObjectRcuFunctionalObjectProxyUnitTestShould
    {
        private RcuController _rcuController;
        private RoomControllerUnit _roomControllerUnit;
        private List<RcuFunctionalObject> _objects;
        private List<Definition.TechnologyType> _technologyTypes;
        private RcuFunctionalObject _rcuFunctionalObject1 = new RcuFunctionalObject("Name100", "100");
        private RcuFunctionalObject _rcuFunctionalObject2 = new RcuFunctionalObject("Name200", "200");
        private RcuFunctionalObject _rcuFunctionalObject3 = new RcuFunctionalObject("Name300", "300");
        private RcuFunctionalObject _rcuFunctionalObject4 = new RcuFunctionalObject("Name400", "400");

        private KeyObject _keyObject1 = new KeyObject("100");
        private KeyObject _keyObject2 = new KeyObject("200");
        private KeyObject _keyObject3 = new KeyObject("300");
        private KeyObject _keyObject4 = new KeyObject("400");

        private Dictionary<KeyObject, RcuFunctionalObject> _proxyDictionnary;

        [SetUp]
        public void InitTest()
        {
            _objects = new List<RcuFunctionalObject>() {
                _rcuFunctionalObject1,
                _rcuFunctionalObject1,
                _rcuFunctionalObject1,
                _rcuFunctionalObject1,
                _rcuFunctionalObject2,
                _rcuFunctionalObject3,
                _rcuFunctionalObject4,
                _rcuFunctionalObject4
            };

            _technologyTypes = new List<Definition.TechnologyType>()
            {
                Definition.TechnologyType.SCS,
                Definition.TechnologyType.Mecanical
            };

            _roomControllerUnit = new RoomControllerUnit(_objects, _technologyTypes);
            _rcuController = new RcuController(_roomControllerUnit);

            _proxyDictionnary = new Dictionary<KeyObject, RcuFunctionalObject>()
            {
                [_keyObject1] = _rcuFunctionalObject1,
                [_keyObject2] = _rcuFunctionalObject2,
                [_keyObject3] = _rcuFunctionalObject3,
                [_keyObject4] = _rcuFunctionalObject4,
            };

        }

        [Test]
        public void Return_rcuFunctionalObject_200_and_instance_0_when_invoked_with_KeyObject_200()
        {
            var _proxy = new KeyObjectRcuFunctionalObjectProxy(_proxyDictionnary);
            var x = _proxy.GetObjectInstance(_keyObject2, _rcuController);
            Check.That(x.RcuFunctionalObject).IsEqualTo(_rcuFunctionalObject2);
            Check.That(x.InstanceNumber).IsEqualTo(0);

        }

        [Test]
        public void Return_rcuFunctionalObject_null_when_invoked_twice_and_only_1_instance_available()
        {
            var _proxy = new KeyObjectRcuFunctionalObjectProxy(_proxyDictionnary);
            var x = _proxy.GetObjectInstance(_keyObject2, _rcuController);
            var y = _proxy.GetObjectInstance(_keyObject2, _rcuController);
            Check.That(y).IsNull();
        }

        [Test]
        public void Return_rcuFunctionalObject_100_and_instance_1_when_invoked_twice_with_KeyObject_100()
        {
            var _proxy = new KeyObjectRcuFunctionalObjectProxy(_proxyDictionnary);
            var x = _proxy.GetObjectInstance(_keyObject1, _rcuController);
            var y = _proxy.GetObjectInstance(_keyObject1, _rcuController);
            Check.That(y.RcuFunctionalObject).IsEqualTo(_rcuFunctionalObject1);
            Check.That(y.InstanceNumber).IsEqualTo(1);

        }

    }
}
