using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using JcfPctClassLibrary.SCS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace JcfPctClassLibraryUnitTest.SCS
{
    [TestClass]
    public class UnitUnitTest
    {
        [TestMethod]
        public void Test_created_Unit_is_of_correct_type()
        {
            var unit = new Unit(ImmutableList.Create<KeyObject>());
            Check.That(unit).IsInstanceOf<Unit>();
        }

        [TestMethod]
        public void Test_created_Unit_stores_list_of_can_do_KeyObjects()
        {
            var canDoKOs = ImmutableList.Create<KeyObject>( new KeyObject("12345"), new KeyObject("78954"));
            var unit = new Unit(canDoKOs);
            Check.That(unit.CanDoKeyObjects.Count()).Equals(canDoKOs.Count());
            Check.That(unit.CanDoKeyObjects).ContainsExactly(canDoKOs);
            unit.CanDoKeyObjects.Add(new KeyObject("22")); // should fail
            Check.That(unit.CanDoKeyObjects.Count()).Equals(canDoKOs.Count());

        }
    }
}
