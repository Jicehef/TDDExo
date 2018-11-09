﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using PctClassLibrary.SCS;
using PctClassLibrary.SCS.Lib;

namespace JcfPctClassLibraryUnitTest.SCS
{

    // todo ?? should be split in more classes ??
    [TestClass]
    public class DeviceIdMethodUnitTest
    {
        [TestMethod]
        public void Should_be_of_DeviceId_type_when_created()
        {
            var id = new DeviceId("12345678");
            Check.That(id).IsInstanceOf<DeviceId>();
        }

        [TestMethod]
        public void Should_return_valid_scs_ids_for_all_values()
        {
            List<string> ids = new List<string>()
            {
                "01234567",
                "6549875D",
                "Abc98745"
            };

            foreach (var id in ids)
            {
                Check.That(DeviceId.IsValid(id)).IsTrue();
            }
        }

        [TestMethod]
        public void Should_return_invalid_scs_ids_for_all_values()
        {
            List<string> ids = new List<string>()
            {
                "0123456",
                "65475D",
                "Abc9845",
                "01234S67",
                "654975D",
                "bc98745",
                "0123115674",
                "654987QD",
                "Abc9845",
                "0-234567",
                "654--875D",
                "Abc/745",

            };

            foreach (var id in ids)
            {
                Check.That(DeviceId.IsValid(id)).IsFalse();
            }
        }

        [TestMethod]
        public void Should_create_an_instance_with_value_passed_in_constructor()
        {
            var deviceId = new DeviceId("12345678");
            Check.That(deviceId.Value).Equals("12345678");
        }

        [TestMethod]
        public void Should_throw_exception_when_value_passed_to_constructor_is_invalid()
        {
            Check.ThatCode(() =>
            {
                var x = new DeviceId("bad-id");
            }).Throws<ArgumentException>();
        }

        [TestMethod]
        public void Should_change_the_value_when_a_new_valid_value_is_given()
        {
            var deviceId = new DeviceId("12345678");
            deviceId.Value = "98765432";
            Check.That(deviceId.Value).Equals("98765432");
        }

        [TestMethod]
        public void Should_throw_exception_when_an_invalid_value_is_passed()
        {
            var deviceId = new DeviceId("12345678");
            Check.ThatCode(() =>
            {
                var x = deviceId.Value = "bad-id";
            }).Throws<ArgumentException>();
        }

        [TestMethod]
        public void Should_be_true_when_a_valid_value_is_passed()
        {
            Check.That(DeviceId.IsValid("12345678")).IsTrue();
        }

        [TestMethod]
        public void Should_be_false_when_a_invalid_value_is_passed()
        {
            Check.That(DeviceId.IsValid("bad-id")).IsFalse();
        }
    }

    [TestClass]
    public class DeviceIdOverrideOperatorUnitTest
    {
        
        #region Test Operator Override
        [TestMethod]
        public void Should_not_be_equal_when_null_values()
        {
            var id1A = new DeviceId("12345678");
            DeviceId id2A = null;
            Check.That(id1A == id2A).IsFalse();
            Check.That(id2A == id1A).IsFalse();
        }

        [TestMethod]
        public void Should_not_be_equal_when_values_are_different()
        {
            var id1A = new DeviceId("12345678");
            var id2A = new DeviceId("65498123");
            Check.That(id1A != id2A).IsTrue();
        }

        [TestMethod]
        public void Should_not_be_different_when_values_are_equal()
        {
            var id1A = new DeviceId("12354321");
            var id2A = new DeviceId("12354321");
            Check.That(id1A != id2A).IsFalse();
        }

        [TestMethod]
        public void Should_not_be_different_when_1_null_value()
        {
            var id1A = new DeviceId("12345678");
            DeviceId id2A = null;
            Check.That(id1A != id2A).IsTrue();
            Check.That(id2A != id1A).IsTrue();
        }
        #endregion
    }

    [TestClass]
    public class DeviceIdOverrideEqualsHashUnitTest
    {


        #region Test Equals Hash Override
        [TestMethod]
        public void Should_be_equal_when_members_are_equal()
        {
            var id1A = new DeviceId("12345678");
            var id2A = new DeviceId("12345678");
            Check.That(id1A.Equals(id2A)).IsTrue();
            Check.That(id1A).Equals(id2A);
        }

        [TestMethod]
        public void Should_not_be_equal_when_members_are_not_equal()
        {
            var id1A = new DeviceId("12345678");
            var id2A = new DeviceId("12354321");
            Check.That(id1A.Equals(id2A)).IsFalse();
        }

        [TestMethod]
        public void Should_not_be_equal_when_member_is_null()
        {
            var id1A = new DeviceId("12345678");
            DeviceId id2A = null;
            Check.That(id1A.Equals(id2A)).IsFalse();
        }

        [TestMethod]
        public void Should_return_value_hash_code()
        {
            var id1A = new DeviceId("12345678");
            var id2A = new DeviceId("12365498");
            Check.That(id1A.GetHashCode()).IsEqualTo("12345678".GetHashCode());
            Check.That(id2A.GetHashCode()).IsEqualTo("12365498".GetHashCode());
        }
        #endregion
    }
}
