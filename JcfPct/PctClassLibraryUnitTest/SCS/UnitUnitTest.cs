using System.Collections.Generic;
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
            var ko1A = new KeyObject("12345");
            var unit = new Unit(new ListOfKeyObjects(new List<KeyObject>() {ko1A}));
            Check.That(unit).IsInstanceOf<Unit>();
        }

        [Test]
        public void Have_in_SelectedKeyObject_first_list_item_selected()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("78954");
 
            var canDo = new ListOfKeyObjects(new List<KeyObject>() { ko1A, ko2A });
            var unit = new Unit(canDo);
            Check.That(unit.SelectedKeyObject).IsEqualTo(ko1A);
        }


        [Test]
        public void Have_SelectKeyObject_can_select_a_KeyObject_in_the_list()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("78954");
            var ko1B = new KeyObject("12345");

            var canDoKOs = new ListOfKeyObjects(new List<KeyObject>(){ko1A, ko2A}) ;
            var unit = new Unit(canDoKOs);
            Check.That(unit.SelectedKeyObject).IsEqualTo(ko1A);

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

            var canDoKOs = new ListOfKeyObjects(new List<KeyObject>() { ko1A, ko2A });
            var unit = new Unit(canDoKOs);
            Check.That(unit.SelectedKeyObject == ko1A);

            Check.That(unit.SelectKeyObject(ko1A)).IsTrue();
            Check.That(unit.SelectedKeyObject == ko1A).IsTrue();

            Check.That(unit.SelectKeyObject(koOther)).IsFalse();
            Check.That(unit.SelectedKeyObject).IsEqualTo(ko1A);
        }

        [Test]
        public void Have_ResetKeyObject_set_the_value_to_first_item_in_list()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("78954");

            var canDoKOs = new ListOfKeyObjects(new List<KeyObject>() { ko1A, ko2A });
            var unit = new Unit(canDoKOs);

            // todo do_we_need_to_check_here_?
            Check.That(unit.SelectedKeyObject == ko1A);

            Check.That(unit.SelectKeyObject(ko1A)).IsTrue();
            Check.That(unit.SelectedKeyObject == ko1A).IsTrue();
            // end todo

            unit.ResetSelectedKeyObject();
            Check.That(unit.SelectedKeyObject).IsEqualTo(ko1A);
        }

    }
}
