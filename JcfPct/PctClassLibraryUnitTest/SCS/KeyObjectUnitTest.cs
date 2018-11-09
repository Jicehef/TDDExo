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
            var ko = new KeyObject("1234");
            Check.That(ko).IsInstanceOf<KeyObject>();
        }

        [Test]
        public void Store_and_retrieve_a_correct_value()
        {
            const string value = "490";
            var ko = new KeyObject(value);
            Check.That(ko.Name).Equals(value);

        }

        #region Test Operator Override
        [Test]
        public void Be_equal_with_same_values()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("12345");
            Check.That(ko1A == ko2A).IsTrue();
        }

        [Test]
        public void Not_be_equal_with_different_values()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("54321");
            Check.That(ko1A == ko2A).IsFalse();
        }

        [Test]
        public void Not_be_equal_with_null_values()
        {
            var ko1A = new KeyObject("12345");
            KeyObject ko2A = null;
            Check.That(ko1A == ko2A).IsFalse();
            Check.That(ko2A == ko1A).IsFalse();
        }

        [Test]
        public void Be_different_with_different_values()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("65498");
            Check.That(ko1A != ko2A).IsTrue();
        }

        [Test]
        public void Not_be_different_with_same_values()
        {
            var ko1A = new KeyObject("54321");
            var ko2A = new KeyObject("54321");
            Check.That(ko1A != ko2A).IsFalse();
        }

        [Test]
        public void Have_difference_not_be_equal_with_null_values()
        {
            var ko1A = new KeyObject("12345");
            KeyObject ko2A = null;
            Check.That(ko1A != ko2A).IsTrue();
            Check.That(ko2A != ko1A).IsTrue();
        }
        #endregion

        #region Test Equals Hash Override
        [Test]
        public void Have_equals_true_with_same_values()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("12345");
            Check.That(ko1A.Equals(ko2A)).IsTrue();
            Check.That(ko1A).Equals(ko2A);
        }

        [Test]
        public void Have_equals_flase_with_different_values()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("54321");
            Check.That(ko1A.Equals(ko2A)).IsFalse();
        }

        [Test]
        public void Test_KeyObject_Equals_override_null_values()
        {
            var ko1A = new KeyObject("12345");
            KeyObject ko2A = null;
            Check.That(ko1A.Equals(ko2A)).IsFalse();
        }

        [Test]
        public void Test_KeyObject_GetHashCode()
        {
            var ko1A = new KeyObject("12345");
            var ko2A = new KeyObject("65498");
            Check.That(ko1A.GetHashCode()).IsEqualTo("12345".GetHashCode());
            Check.That(ko2A.GetHashCode()).IsEqualTo("65498".GetHashCode());
        }
        #endregion

    }
}
