using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;
using PctClassLibrary.SCS;

namespace PctClassLibraryUnitTest.SCS
{
    class ListOfKeyObjectsShould
    {

        [Test]
        public void Be_of_ListOfKeyObjects_type_when_created()
        {
            var listOfKeyObjects = new ListOfKeyObjects(new List<KeyObject>());
            Check.That(listOfKeyObjects).IsInstanceOf<ListOfKeyObjects>();
        }

        [Test]
        public void Be_equal_to_another_containing_same_key_objects()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("45678");
            var ko3A = new KeyObject("32187");

            var list1 = new List<KeyObject>() { ko1A, ko2A, ko3A };
            var list2 = new List<KeyObject>() { ko2A, ko3A, ko1A };

            Check.That(new ListOfKeyObjects(list1)).IsEqualTo(new ListOfKeyObjects(list2));
        }
        [Test]
        public void Not_be_equal_to_another_containing_same_key_objects()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("45678");
            var ko3A = new KeyObject("32187");

            var list1 = new List<KeyObject>() { ko1A, ko2A, ko3A };
            var list2 = new List<KeyObject>() { ko2A, ko1A };

            Check.That(new ListOfKeyObjects(list1)).IsNotEqualTo(new ListOfKeyObjects(list2));
        }

        [Test]
        public void Find_a_key_object_present_in_the_list()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("45678");
            var ko3A = new KeyObject("32187");
            var ko2Find = new KeyObject("12345");

            var list1 = new List<KeyObject>() { ko1A, ko2A, ko3A };
            var listOfKeyObjects = new ListOfKeyObjects(list1);

            Check.That(listOfKeyObjects.IsInList(ko2Find)).IsTrue();
        }
        [Test]
        public void Not_find_a_key_object_present_in_the_list()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("45678");
            var ko3A = new KeyObject("32187");
            var ko2Find = new KeyObject("54879");

            var list1 = new List<KeyObject>() { ko1A, ko2A, ko3A };
            var listOfKeyObjects = new ListOfKeyObjects(list1);

            Check.That(listOfKeyObjects.IsInList(ko2Find)).IsFalse();
        }


    }
}
