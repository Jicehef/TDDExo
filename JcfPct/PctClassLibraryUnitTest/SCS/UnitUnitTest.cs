﻿using System.Collections.Immutable;
using NFluent;
using NUnit.Framework;
using PctClassLibrary.SCS;

namespace PctClassLibraryUnitTest.SCS
{

    public class UnitShould
    {
        [Test]
        public void Create_instance_of_correct_type()
        {
            var unit = new Unit(ImmutableList.Create<KeyObject>());
            Check.That(unit).IsInstanceOf<Unit>();
        }

        [Test]
        public void Create_Unit_with_list_of_can_do_KeyObjects()
        {
            var canDoKOs = ImmutableList.Create<KeyObject>(new KeyObject("12345"), new KeyObject("78954"));
            var unit = new Unit(canDoKOs);
            Check.That(unit.CanDoKeyObjects.Count()).Equals(canDoKOs.Count());
            Check.That(unit.CanDoKeyObjects).ContainsExactly(canDoKOs);
            unit.CanDoKeyObjects.Add(new KeyObject("22")); // should fail
            Check.That(unit.CanDoKeyObjects.Count()).Equals(canDoKOs.Count());

        }

        [Test]
        public void Have_SelectKeyObject_can_select_a_KeyObject_in_the_list()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("78954");
            var ko1B = new KeyObject("12345");

            var canDoKOs = ImmutableList.Create<KeyObject>(ko1A, ko2A);
            var unit = new Unit(canDoKOs);
            Check.That(unit.SelectedKeyObject == null);

            Check.That(unit.SelectKeyObject(ko1A)).IsTrue();
            Check.That(unit.SelectedKeyObject == ko1A).IsTrue();
            Check.That(unit.SelectedKeyObject == ko1B).IsTrue();

        }

        [Test]
        public void Have_SelectKeyObject_can_not_select_a_KeyObject_not_in_the_list()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("78954");
            var koOther = new KeyObject("9999");

            var canDoKOs = ImmutableList.Create<KeyObject>(ko1A, ko2A);
            var unit = new Unit(canDoKOs);
            Check.That(unit.SelectedKeyObject == null);

            Check.That(unit.SelectKeyObject(ko1A)).IsTrue();
            Check.That(unit.SelectedKeyObject == ko1A).IsTrue();

            Check.That(unit.SelectKeyObject(koOther)).IsFalse();
            Check.That(unit.SelectedKeyObject).IsNull();

        }

        [Test]
        public void Have_ResetKeyObject_set_the_value_to_null()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("78954");
            var koOther = new KeyObject("9999");

            var canDoKOs = ImmutableList.Create<KeyObject>(ko1A, ko2A);
            var unit = new Unit(canDoKOs);
            #region do_we_need_to_check_here_?
            Check.That(unit.SelectedKeyObject == null);

            Check.That(unit.SelectKeyObject(ko1A)).IsTrue();
            Check.That(unit.SelectedKeyObject == ko1A).IsTrue();
            #endregion

            unit.ResetSelectedKeyObject();
            Check.That(unit.SelectedKeyObject).IsNull();

        }
    }
}
