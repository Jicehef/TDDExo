using System;
using NFluent;
using NUnit.Framework;
using PctClassLibrary.SCS;

namespace PctClassLibraryUnitTest.SCS
{
    public class KeyObjectShould
    {
        [Test]
        public void Create_object_of_correct_type()
        {
            var ko = new KeyObject("123");
            Check.That(ko).IsInstanceOf<KeyObject>();
        }

        [Test]
        public void Store_and_retrieve_a_correct_value()
        {
            const string value = "490";
            var ko = new KeyObject(value);
            Check.That(ko.Name).Equals(value);

        }

        [Test]
        public void Throw_exception_when_value_passed_to_constructor_is_invalid()
        {
            Check.ThatCode(() =>
            {
                var x = new KeyObject("bad-name");
            }).Throws<ArgumentException>();
        }

        [Test]
        public void Be_valid_when_a_valid_value_is_passed()
        {
            Check.That(KeyObject.IsValid("123")).IsTrue();
        }

        [Test]
        public void Not_be_valid_when_a_invalid_value_is_passed()
        {
            Check.That(KeyObject.IsValid("12345")).IsFalse();
        }

        #region Test Operator Override
        [Test]
        public void Be_equal_with_same_values()
        {
            var ko1A = new KeyObject("123");
            var ko2A = new KeyObject("123");
            Check.That(ko1A == ko2A).IsTrue();
        }

        [Test]
        public void Not_be_equal_with_different_values()
        {
            var ko1A = new KeyObject("125");
            var ko2A = new KeyObject("543");
            Check.That(ko1A == ko2A).IsFalse();
        }

        [Test]
        public void Not_be_equal_with_null_values()
        {
            var ko1A = new KeyObject("123");
            KeyObject ko2A = null;
            Check.That(ko1A == ko2A).IsFalse();
            Check.That(ko2A == ko1A).IsFalse();
        }

        [Test]
        public void Be_different_with_different_values()
        {
            var ko1A = new KeyObject("123");
            var ko2A = new KeyObject("654");
            Check.That(ko1A != ko2A).IsTrue();
        }

        [Test]
        public void Not_be_different_with_same_values()
        {
            var ko1A = new KeyObject("543");
            var ko2A = new KeyObject("543");
            Check.That(ko1A != ko2A).IsFalse();
        }
        #endregion

        #region Test Equals Hash Override
        [Test]
        public void Have_equals_true_with_same_values()
        {
            var ko1A = new KeyObject("123");
            var ko2A = new KeyObject("123");
            Check.That(ko1A.Equals(ko2A)).IsTrue();
            Check.That(ko1A).Equals(ko2A);
        }

        [Test]
        public void Have_equals_false_with_different_values()
        {
            var ko1A = new KeyObject("123");
            var ko2A = new KeyObject("543");
            Check.That(ko1A.Equals(ko2A)).IsFalse();
        }

        [Test]
        public void Not_Equals_with_null_values()
        {
            var ko1A = new KeyObject("123");
            KeyObject ko2A = null;
            Check.That(ko1A.Equals(ko2A)).IsFalse();
        }

        [Test]
        public void Implement_GetHashCode()
        {
            var ko1A = new KeyObject("123");
            var ko2A = new KeyObject("654");
            Check.That(ko1A.GetHashCode()).IsEqualTo("123".GetHashCode());
            Check.That(ko2A.GetHashCode()).IsEqualTo("654".GetHashCode());
        }
        #endregion

        [TestCase("13")]
        [TestCase("1024")]
        [TestCase("7948")]
        [TestCase("45")]
        public void Have_invalid_values(string name)
        {
            Check.That(KeyObject.IsValid(name)).IsFalse();
        }

        [TestCase("123")]
        [TestCase("102")]
        [TestCase("798")]
        [TestCase("451")]
        public void Have_valid_values(string name)
        {
            Check.That(KeyObject.IsValid(name)).IsTrue();
        }

    }
}
