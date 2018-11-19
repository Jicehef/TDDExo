﻿using System;
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
            var ko1A = new KeyObject("12345");
            var listOfKeyObjects = new ListOfKeyObjects(new List<KeyObject>() { ko1A });
            Check.That(listOfKeyObjects).IsInstanceOf<ListOfKeyObjects>();
        }

        [Test]
        public void Throw_an_exception_when_an_empty_list_is_passed()
        {
            // my business rule says a unit MUST have at least 1 KO
            Check.ThatCode(() => { new ListOfKeyObjects(new List<KeyObject>()); }).Throws<ArgumentException>();
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

        [Test]
        public void Return_a_list_containing_all_items()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("45678");
            var ko3A = new KeyObject("32187");

            var list1 = new List<KeyObject>() { ko1A, ko2A, ko3A };
            var listOfKeyObjects = new ListOfKeyObjects(list1);

            Check.That(listOfKeyObjects.GetList()).ContainsExactly(list1);
        }

        [Test]
        public void Return_a_list_containing_original_instances_of_KeyObject_not_copies()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("45678");
            var ko3A = new KeyObject("32187");

            var list1 = new List<KeyObject>() { ko1A, ko2A, ko3A };
            var listOfKeyObjects = new ListOfKeyObjects(list1);
            var list2 = listOfKeyObjects.GetList();

            Check.That(ko1A).IsEqualTo(list2[0]).And.IsSameReferenceAs(list2[0]);
        }

        [Test]
        public void Count_returns_3()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("45678");
            var ko3A = new KeyObject("32187");

            var list1 = new List<KeyObject>() { ko1A, ko2A, ko3A };
            var listOfKeyObjects = new ListOfKeyObjects(list1);

            Check.That(listOfKeyObjects.Count()).IsEqualTo(3);
        }

        [Test]
        public void Have_GetFirstItem_returns_first_item_in_parameter_list()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("45678");
            var ko3A = new KeyObject("32187");

            var list1 = new List<KeyObject>() { ko1A, ko2A, ko3A };
            var listOfKeyObjects = new ListOfKeyObjects(list1);

            Check.That(listOfKeyObjects.GetFirstItem()).IsEqualTo(ko1A);
        }

    }
}
