using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using PctClassLibrary.SCS;
using PctClassLibrary.SCS.Lib;

namespace JcfPctClassLibraryUnitTest.SCS
{
    [TestClass]
    public class DeviceIdUnitTest
    {
        [TestMethod]
        public void Test_created_DeviceId_is_of_correct_type()
        {
            var id = new DeviceId("12345678");
            Check.That(id).IsInstanceOf<DeviceId>();
        }

        [TestMethod]
        public void Test_valid_scs_ids()
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
        public void Test_invalid_scs_ids()
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
        public void Test_constructor_set_valid_DeviceId()
        {
            var deviceId = new DeviceId("12345678");
            Check.That(deviceId.Value).Equals("12345678");
        }

        [TestMethod]
        public void Test_constructor_invalid_DeviceId_throws_exception()
        {
            Check.ThatCode(() => { var x = new DeviceId("bad-id"); }).Throws<ArgumentException>();
        }

        [TestMethod]
        public void Test_value_set_valid_DeviceId()
        {
            var deviceId = new DeviceId("12345678");
            deviceId.Value = "98765432";
            Check.That(deviceId.Value).Equals("98765432");
        }

        [TestMethod]
        public void Test_value_invalid_DeviceId_throws_exception()
        {
            var deviceId = new DeviceId("12345678");
            Check.ThatCode(() => { var x = deviceId.Value = "bad-id"; }).Throws<ArgumentException>();
        }
        [TestMethod]
        public void Test_value_is_a_valid_DeviceId()
        {
            Check.That(DeviceId.IsValid("12345678")).IsTrue();
        }

        [TestMethod]
        public void Test_value_is_a_invalid_DeviceId()
        {
            Check.That(DeviceId.IsValid("bad-id")).IsFalse();
        }


        #region Test Operator Override
        [TestMethod]
        public void Test_DeviceId_equal_operator_override_null_values()
        {
            var id1A = new DeviceId("12345678");
            DeviceId id2A = null;
            Check.That(id1A == id2A).IsFalse();
            Check.That(id2A == id1A).IsFalse();
        }

        [TestMethod]
        public void Test_DeviceId_not_equal_operator_override_are_equal()
        {
            var id1A = new DeviceId("12345678");
            var id2A = new DeviceId("65498123");
            Check.That(id1A != id2A).IsTrue();
        }

        [TestMethod]
        public void Test_DeviceId_not_equal_operator_override_are_not_equal()
        {
            var id1A = new DeviceId("12354321");
            var id2A = new DeviceId("12354321");
            Check.That(id1A != id2A).IsFalse();
        }

        [TestMethod]
        public void Test_DeviceId_not_equal_operator_override_null_values()
        {
            var id1A = new DeviceId("12345678");
            DeviceId id2A = null;
            Check.That(id1A != id2A).IsTrue();
            Check.That(id2A != id1A).IsTrue();
        }
        #endregion

        #region Test Equals Hash Override
        [TestMethod]
        public void Test_DeviceId_Equals_override_are_equal()
        {
            var id1A = new DeviceId("12345678");
            var id2A = new DeviceId("12345678");
            Check.That(id1A.Equals(id2A)).IsTrue();
            Check.That(id1A).Equals(id2A);
        }

        [TestMethod]
        public void Test_DeviceId_Equals_override_are_not_equal()
        {
            var id1A = new DeviceId("12345678");
            var id2A = new DeviceId("12354321");
            Check.That(id1A.Equals(id2A)).IsFalse();
        }

        [TestMethod]
        public void Test_DeviceId_Equals_override_null_values()
        {
            var id1A = new DeviceId("12345678");
            DeviceId id2A = null;
            Check.That(id1A.Equals(id2A)).IsFalse();
        }

        [TestMethod]
        public void Test_DeviceId_GetHashCode()
        {
            var id1A = new DeviceId("12345678");
            var id2A = new DeviceId("12365498");
            Check.That(id1A.GetHashCode()).IsEqualTo("12345678".GetHashCode());
            Check.That(id2A.GetHashCode()).IsEqualTo("12365498".GetHashCode());
        }
        #endregion
    }
}
