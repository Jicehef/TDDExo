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
            var ko = new DeviceId("12345678");
            Check.That(ko).IsInstanceOf<DeviceId>();
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
                Check.That(DeviceId.IsValidId(id)).IsTrue();
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
                Check.That(DeviceId.IsValidId(id)).IsFalse();
            }
        }

        [TestMethod]
        public void Test_set_valid_DeviceId()
        {
            var deviceId = new DeviceId("12345678");
            Check.That(deviceId.Id).Equals("12345678");
        }

        [TestMethod]
        public void Test_invalid_DeviceId_throws_exception()
        {
            Check.ThatCode(() => { var x = new DeviceId("bad-id"); }).Throws<ArgumentException>();
        }
    }
}
