﻿using System;
using NFluent;
using NUnit.Framework;
using PctClassLibrary.SCS;

namespace PctClassLibraryUnitTest.SCS
{

    // todo ?? should be split in more classes ??
    public class DeviceIdShould
    {
        [Test]
        public void Be_of_DeviceId_type_when_created()
        {
            var id = new DeviceId("12345678");
            Check.That(id).IsInstanceOf<DeviceId>();
        }

        [TestCase("01234567")]
        [TestCase("6549875D")]
        [TestCase("Abc98745")]
        public void Return_valid_scs_ids_for_all_values(string id)
        {
                Check.That(DeviceId.IsValid(id)).IsTrue();
        }

        [TestCase("0123456")]
        [TestCase("65475D")]
        [TestCase("Abc9845")]
        [TestCase("01234S67")]
        [TestCase("654975D")]
        [TestCase("bc98745")]
        [TestCase("0123115674")]
        [TestCase("654987QD")]
        [TestCase("Abc9845")]
        [TestCase("0-234567")]
        [TestCase("654--875D")]
        [TestCase("Abc/745")]
        public void Return_invalid_scs_ids_for_all_values(string id)
        {
                Check.That(DeviceId.IsValid(id)).IsFalse();
        }

        [Test]
        public void Create_an_instance_with_value_passed_in_constructor()
        {
            var deviceId = new DeviceId("12345678");
            Check.That(deviceId.Value).Equals("12345678");
        }

        [Test]
        public void Throw_exception_when_value_passed_to_constructor_is_invalid()
        {
            Check.ThatCode(() =>
            {
                var x = new DeviceId("bad-id");
            }).Throws<ArgumentException>();
        }

        [Test]
        public void Change_the_value_when_a_new_valid_value_is_given()
        {
            var deviceId = new DeviceId("12345678");
            deviceId.Value = "98765432";
            Check.That(deviceId.Value).Equals("98765432");
        }

        [Test]
        public void Throw_exception_when_an_invalid_value_is_passed()
        {
            var deviceId = new DeviceId("12345678");
            Check.ThatCode(() =>
            {
                var x = deviceId.Value = "bad-id";
            }).Throws<ArgumentException>();
        }

        [Test]
        public void Be_valid_when_a_valid_value_is_passed()
        {
            Check.That(DeviceId.IsValid("12345678")).IsTrue();
        }

        [Test]
        public void Not_be_valid_when_a_invalid_value_is_passed()
        {
            Check.That(DeviceId.IsValid("bad-id")).IsFalse();
        }

        #region Test Operator Override
        [Test]
        public void Not_be_equal_when_null_values()
        {
            var id1A = new DeviceId("12345678");
            DeviceId id2A = null;
            Check.That(id1A == id2A).IsFalse();
            Check.That(id2A == id1A).IsFalse();
        }

        [Test]
        public void Not_be_equal_when_values_are_different()
        {
            var id1A = new DeviceId("12345678");
            var id2A = new DeviceId("65498123");
            Check.That(id1A != id2A).IsTrue();
        }

        [Test]
        public void Not_be_different_when_values_are_equal()
        {
            var id1A = new DeviceId("12354321");
            var id2A = new DeviceId("12354321");
            Check.That(id1A != id2A).IsFalse();
        }

        [Test]
        public void Not_be_different_when_1_null_value()
        {
            var id1A = new DeviceId("12345678");
            DeviceId id2A = null;
            Check.That(id1A != id2A).IsTrue();
            Check.That(id2A != id1A).IsTrue();
        }
        #endregion

        #region Test Equals Hash Override
        [Test]
        public void Be_equal_when_members_are_equal()
        {
            var id1A = new DeviceId("12345678");
            var id2A = new DeviceId("12345678");
            Check.That(id1A.Equals(id2A)).IsTrue();
            Check.That(id1A).Equals(id2A);
        }

        [Test]
        public void Not_be_equal_when_members_are_not_equal()
        {
            var id1A = new DeviceId("12345678");
            var id2A = new DeviceId("12354321");
            Check.That(id1A.Equals(id2A)).IsFalse();
        }

        [Test]
        public void Not_be_equal_when_member_is_null()
        {
            var id1A = new DeviceId("12345678");
            DeviceId id2A = null;
            Check.That(id1A.Equals(id2A)).IsFalse();
        }

        [Test]
        public void Return_value_hash_code()
        {
            var id1A = new DeviceId("12345678");
            var id2A = new DeviceId("12365498");
            Check.That(id1A.GetHashCode()).IsEqualTo("12345678".GetHashCode());
            Check.That(id2A.GetHashCode()).IsEqualTo("12365498".GetHashCode());
        }
        #endregion
    }
}