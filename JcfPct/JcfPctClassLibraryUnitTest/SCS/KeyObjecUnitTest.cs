using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

using JcfPctClassLibrary.SCS;

namespace JcfPctClassLibraryUnitTest
{
    [TestClass]
    public class KeyObjecUnitTest
    {
        [TestMethod]
        public void Test_created_KeyObject_is_of_correct_type()
        {
            var ko = new KeyObject("1234");
            Check.That(ko).IsInstanceOf<KeyObject>();
        }

        [TestMethod]
        public void Test_KeyObject_has_correct_value()
        {
            const string value = "490";
            var ko = new KeyObject(value);
            Check.That(ko.Name).Equals(value);

        }

    }
}
