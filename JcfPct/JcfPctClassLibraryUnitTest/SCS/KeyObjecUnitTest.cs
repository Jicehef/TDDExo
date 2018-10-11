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

        [TestMethod]
        public void Test_KeyObject_equal_operator_override_are_equal()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("12345");
            Check.That(ko1A == ko2A).IsTrue();
        }

        [TestMethod]
        public void Test_KeyObject_equal_operator_override_are_not_equal()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("54321");
            Check.That(ko1A == ko2A).IsFalse();
        }

        [TestMethod]
        public void Test_KeyObject_equal_operator_override_null_values()
        {
            var ko1A = new KeyObject("12345");
            KeyObject ko2A = null;
            Check.That(ko1A == ko2A).IsFalse();
            Check.That(ko2A == ko1A).IsFalse();
        }

        [TestMethod]
        public void Test_KeyObject_not_equal_operator_override_are_equal()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("65498");
            Check.That(ko1A != ko2A).IsTrue();
        }

        [TestMethod]
        public void Test_KeyObject_not_equal_operator_override_are_not_equal()
        {
            var ko1A = new KeyObject("54321");
            var ko2A = new KeyObject("54321");
            Check.That(ko1A != ko2A).IsFalse();
        }

        [TestMethod]
        public void Test_KeyObject_not_equal_operator_override_null_values()
        {
            var ko1A = new KeyObject("12345");
            KeyObject ko2A = null;
            Check.That(ko1A != ko2A).IsTrue();
            Check.That(ko2A != ko1A).IsTrue();
        }

    }
}
