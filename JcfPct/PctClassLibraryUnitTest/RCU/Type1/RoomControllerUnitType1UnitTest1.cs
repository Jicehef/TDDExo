using System.Collections.Generic;
using NFluent;
using NUnit.Framework;
using PctClassLibrary.Common;
using PctClassLibrary.RCU;
using PctClassLibrary.RCU.Type1;
using PctClassLibrary.SCS;

namespace PctClassLibraryUnitTest.RCU.Type1
{
    public class RoomControllerUnitShould
    {
        private List<RcuFunctionnalObject> _objects;
        private List<Definition.TechnologyType>  _technologyTypes;
        private RcuFunctionnalObject _rcuFunctionnalObject1 = new RcuFunctionnalObject("Name100", "100");
        private RcuFunctionnalObject _rcuFunctionnalObject2 = new RcuFunctionnalObject("Name200", "200");
        private RcuFunctionnalObject _rcuFunctionnalObject3 = new RcuFunctionnalObject("Name300", "300");
        private RcuFunctionnalObject _rcuFunctionnalObject4 = new RcuFunctionnalObject("Name400", "400");

        [SetUp]
        public void Test_Init()
        {

           _objects = new List<RcuFunctionnalObject>() {
               _rcuFunctionnalObject1,
               _rcuFunctionnalObject2,
               _rcuFunctionnalObject3,
               _rcuFunctionnalObject4
           };

            _technologyTypes = new List<Definition.TechnologyType>()
            {
                Definition.TechnologyType.SCS,
                Definition.TechnologyType.Mecanical
            };
        }

        [Test]
        public void Create_instance_of_correct_type()
        {
            var rcu = new RoomControllerUnit(_objects, _technologyTypes);

            Check.That(rcu).IsInstanceOf<RoomControllerUnit>();
        }

        [Test]
        public void Retrieve_TechnologyType_present_in_list()
        {
            var rcu = new RoomControllerUnit(_objects, _technologyTypes);

            Check.That(rcu.IsTechnologyValid(Definition.TechnologyType.SCS)).IsTrue();
        }

        [Test]
        public void Not_retrieve_TechnologyType_present_in_list()
        {
            var rcu = new RoomControllerUnit(_objects, _technologyTypes);

            Check.That(rcu.IsTechnologyValid(Definition.TechnologyType.KNX)).IsFalse();
        }

        //[Test]
        //public void Have_GetRcuObject_return_1_instance_with_instance_0()
        //{
        //    var rcu = new RoomControllerUnit(_objects, _technologyTypes);
        //    Check.That( rcu.GetRcuObjects()).ContainsExactly(new )
        //}

    }
}
