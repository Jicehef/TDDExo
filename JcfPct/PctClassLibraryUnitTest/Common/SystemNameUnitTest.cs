using NFluent;
using NUnit.Framework;
using PctClassLibrary.Common;

namespace PctClassLibraryUnitTest.Common
{
    public class SystemNameShould

    {
        [Test]
        public void Store_and_retrieve_correct_value()
        {
            var sn = new SystemName();
            sn.Value = "My ref";
            Check.That(sn.Value).IsEqualTo("My ref");
        }

        [Test]
        public void Allow_a_change_of_value()
        {
            var sn = new SystemName();
            sn.Value = "My ref";
            sn.Value = "New ref";
            Check.That(sn.Value).IsEqualTo("New ref");
        }

        [Test]
        public void Create_an_instance_with_NoName_default_value()
        {
            var sn = new SystemName();
            Check.That(sn.Value).IsEqualTo("NoName");
        }
        
        [Test]
        public void Create_an_instance_with_a_correct_value_retrieve_it()
        {
            var sn = new SystemName("MyValue");
            Check.That(sn.Value).IsEqualTo("MyValue");
        }

        [TestCase("Indicator-01")]
        [TestCase("Indicator_4501")]
        [TestCase("min4")]
        [TestCase("max20max20max20max20")]
        public void Have_the_values_valid(string sn)
        {
            Check.That(SystemName.IsValid(sn)).IsTrue();
        }

        [TestCase("Indicator 01")]
        [TestCase("no3")]
        [TestCase("no-more-than-20-char-because-too-much")]
        [TestCase("forbiddenchar/")]
        [TestCase("forbiddenchar\\")]
        [TestCase("forbiddenchar*")]
        [TestCase("forbiddenchar+")]
        [TestCase("forbiddenchar%")]
        [TestCase("forbiddenchar&")]
        public void Test_invalid_system_names(string sn)
        {
            Check.That(SystemName.IsValid(sn)).IsFalse();
        }

        [Test]
        public void Not_be_equal_with_null_values()
        {
            var sn1A = new SystemName("12345");
            SystemName sn2A = null;
            Check.That(sn1A == sn2A).IsFalse();
            Check.That(sn2A == sn1A).IsFalse();
        }

        [Test]
        public void Be_different_when_operators_are_different()
        {
            var sn1A = new SystemName("12345");
            var sn2A = new SystemName("65498");
            Check.That(sn1A != sn2A).IsTrue();
        }

        [Test]
        public void Not_be_different_when_operators_are_the_same()
        {
            var sn1A = new SystemName("54321");
            var sn2A = new SystemName("54321");
            Check.That(sn1A != sn2A).IsFalse();
        }

        [Test]
        public void Be_different_with_null_values()
        {
            var sn1A = new SystemName("12345");
            SystemName sn2A = null;
            Check.That(sn1A != sn2A).IsTrue();
            Check.That(sn2A != sn1A).IsTrue();
        }

        #region Test Equals Hash Override
        [Test]
        public void Equals_with_same_values()
        {
            var sn1A = new SystemName("12345");
            var sn2A = new SystemName("12345");
            Check.That(sn1A.Equals(sn2A)).IsTrue();
            Check.That(sn1A).Equals(sn2A);
        }

        [Test]
        public void Not_equals_with_different_values()
        {
            var sn1A = new SystemName("12345");
            var sn2A = new SystemName("54321");
            Check.That(sn1A.Equals(sn2A)).IsFalse();
        }

        [Test]
        public void Not_equals_with_null_values()
        {
            var sn1A = new SystemName("12345");
            SystemName sn2A = null;
            Check.That(sn1A.Equals(sn2A)).IsFalse();
        }

        [Test]
        public void Implement_GetHashCode()
        {
            var sn1A = new SystemName("12345");
            var sn2A = new SystemName("65498");
            Check.That(sn1A.GetHashCode()).IsEqualTo("12345".GetHashCode());
            Check.That(sn2A.GetHashCode()).IsEqualTo("65498".GetHashCode());
        }
        #endregion

    }
}
