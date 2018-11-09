﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using NFluent;
using NUnit.Framework;
using PctClassLibrary.Common;
using PctClassLibrary.SCS;

namespace PctClassLibraryUnitTest.SCS
{
    [TestFixture]
    public class DeviceShould
    {
        Unit[] units = new Unit[4];
        private SystemName identificator = new SystemName("identificator01");
        DeviceId deviceId = new DeviceId("12345678");
        Dictionary<string, KeyObject> keyObjects;

        [SetUp]
        public void Test_Init()
        {
            keyObjects = new Dictionary<string, KeyObject>();
            List<String> koNames = new List<string>() {"123", "234", "345", "456", "567", "678"};
            foreach (var koName in koNames)
            {
                keyObjects.Add(koName, new KeyObject(koName));
            }

            units[0] = new Unit(ImmutableList.Create<KeyObject>(keyObjects.ElementAt(0).Value));
            units[1] = new Unit(ImmutableList.Create<KeyObject>(keyObjects.ElementAt(1).Value));
            units[2] = new Unit(ImmutableList.Create<KeyObject>(keyObjects.ElementAt(2).Value, keyObjects.ElementAt(4).Value));
            units[3] = new Unit(ImmutableList.Create<KeyObject>(keyObjects.ElementAt(3).Value, keyObjects.ElementAt(5).Value));
        }

        [Test]
        public void Create_an_instance_of_correct_type()
        {
            var device = new Device(identificator, deviceId, new Unit[1]);
            Check.That(device).IsInstanceOf<Device>();
        }

        [Test]
        public void Create_Device_with_correct_id()
        {
            var device = new Device(identificator, deviceId, new Unit[1]);

            Check.That(device.BusID).IsEqualTo(deviceId);
            Check.That(device.BusID.Value).IsEqualTo("12345678");
        }

        [Test]
        public void Accept_and_retrieve_units()
        {
            var product = new Device(identificator, deviceId, units);
            Check.That(product.Units.Count()).IsEqualTo(units.Count());
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 2)]
        [TestCase(5, 3)]
        public void Select_a_valid_ko_for_unit(int koListIndex, int unitIndex)
        {
            var product = new Device(identificator, deviceId, units);

            var successful = product.SelectKeyObject4Unit(keyObjects.ElementAt(koListIndex).Value, unitIndex);
            Check.That(successful).IsTrue();
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 2)]
        [TestCase(5, 3)]
        public void Retrieve_selected_ko_for_unit(int koListIndex, int unitIndex)
        {
            var product = new Device(identificator, deviceId, units);
           
            product.SelectKeyObject4Unit(keyObjects.ElementAt(koListIndex).Value, unitIndex);
            var ko = product.GetKeyObject4Unit(unitIndex);
            Check.That(ko == keyObjects.ElementAt(koListIndex).Value).IsTrue();
        }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(5, 2)]
        public void Not_select_an_invalid_ko_for_a_unit(int koListIndex, int unitIndex)
        {
            var product = new Device(identificator, deviceId, units);
            Check.That(product.SelectKeyObject4Unit(keyObjects.ElementAt(koListIndex).Value, unitIndex)).IsFalse();
        }

        [Test]
        public void Have_GetKeyObject4Unit_raise_an_exception_when_unit_index_is_out_of_bounds()
        {
            var product = new Device(identificator, deviceId, units);
            Check.ThatCode(() =>
            {
                var result = product.GetKeyObject4Unit(10);
            }).Throws<System.ArgumentException>();
        }

        [Test]
        public void Have_SelectKeyObject4Unit_raise_an_exception_when_unit_index_is_out_of_bounds()
        {
            var product = new Device(identificator, deviceId, units);
            Check.ThatCode(() =>
            {
                var result = product.SelectKeyObject4Unit(keyObjects.ElementAt(4).Value, 10);
            }).Throws<System.ArgumentException>();
        }
    }
}