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
        private List<RcuFunctionalObject> _objects;
        private List<Definition.TechnologyType>  _technologyTypes;
        private RcuFunctionalObject _rcuFunctionalObject1 = new RcuFunctionalObject("Name100", "100");
        private RcuFunctionalObject _rcuFunctionalObject2 = new RcuFunctionalObject("Name200", "200");
        private RcuFunctionalObject _rcuFunctionalObject3 = new RcuFunctionalObject("Name300", "300");
        private RcuFunctionalObject _rcuFunctionalObject4 = new RcuFunctionalObject("Name400", "400");

        [SetUp]
        public void Test_Init()
        {

           _objects = new List<RcuFunctionalObject>() {
               _rcuFunctionalObject1,
               _rcuFunctionalObject2,
               _rcuFunctionalObject3,
               _rcuFunctionalObject4
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
        //public void Have_GetRcuFunctionalObject_return_1_instance_with_instance_0()
        //{
        //    var rcu = new RoomControllerUnit(_objects, _technologyTypes);
        //    Check.That( rcu.GetRcuFunctionalObjects()).ContainsExactly(new )
        //}

    }
}
