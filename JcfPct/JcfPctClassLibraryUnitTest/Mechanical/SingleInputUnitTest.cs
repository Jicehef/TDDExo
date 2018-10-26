using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using PctClassLibrary.Common;
using PctClassLibrary.Mechanical;

namespace JcfPctClassLibraryUnitTest.Mechanical
{
    [TestClass]
    public class SingleInputUnitTest
    {
        [TestMethod]
        public void Test_name_can_be_set()
        {
            var x = new SingleInput("mySingleInput");
            Check.That(x.SystemName.Value).IsEqualTo("mySingleInput");
        }

        [TestMethod]
        public void Test_name_can_be_changed()
        {
            var x = new SingleInput("mySingleInput");
            x.SystemName = new SystemName("NewName");
            Check.That(x.SystemName.Value).IsEqualTo("NewName");
        }
    }
}
