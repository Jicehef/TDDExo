using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using PctClassLibrary.Common;

namespace JcfPctClassLibraryUnitTest.SCS
{
    [TestClass]
    public class SystemNameUnitTest

    {
        [TestMethod]
        public void Test_value_is_correctly_stored()
        {
            var sn = new SystemName();
            sn.Value = "My ref";
            Check.That(sn.Value).IsEqualTo("My ref");
        }

        [TestMethod]
        public void Test_value_can_be_changed()
        {
            var sn = new SystemName();
            sn.Value = "My ref";
            sn.Value = "New ref";
            Check.That(sn.Value).IsEqualTo("New ref");
        }

        [TestMethod]
        public void Test_default_constructor_to_NoName()
        {
            var sn = new SystemName();
            Check.That(sn.Value).IsEqualTo("NoName");
        }


        [TestMethod]
        public void Test_constructor_to_value()
        {
        var sn = new SystemName("MyValue");
        Check.That(sn.Value).IsEqualTo("MyValue");
        }

        [TestMethod]
        public void Test_valid_system_names()
        {
            Check.That(SystemName.IsValid("Indicator-01")).IsTrue();
            Check.That(SystemName.IsValid("Indicator_4501")).IsTrue();
            Check.That(SystemName.IsValid("min4")).IsTrue();
            Check.That(SystemName.IsValid("max20max20max20max20")).IsTrue();
        }

        [TestMethod]
        public void Test_invalid_system_names()
        {
            Check.That(SystemName.IsValid("Indicator 01")).IsFalse();
            Check.That(SystemName.IsValid("no3")).IsFalse();
            Check.That(SystemName.IsValid("no-more-than-20-char-because-too-much")).IsFalse();
            Check.That(SystemName.IsValid("forbiddenchar/")).IsFalse();
            Check.That(SystemName.IsValid("forbiddenchar\\")).IsFalse();
            Check.That(SystemName.IsValid("forbiddenchar*")).IsFalse();
            Check.That(SystemName.IsValid("forbiddenchar+")).IsFalse();
            Check.That(SystemName.IsValid("forbiddenchar%")).IsFalse();
            Check.That(SystemName.IsValid("forbiddenchar&")).IsFalse();
        }
        [TestMethod]
        public void Test_SystemName_equal_operator_override_null_values()
        {
            var sn1A = new SystemName("12345");
            SystemName sn2A = null;
            Check.That(sn1A == sn2A).IsFalse();
            Check.That(sn2A == sn1A).IsFalse();
        }

        [TestMethod]
        public void Test_SystemName_not_equal_operator_override_are_equal()
        {
            var sn1A = new SystemName("12345");
            var sn2A = new SystemName("65498");
            Check.That(sn1A != sn2A).IsTrue();
        }

        [TestMethod]
        public void Test_SystemName_not_equal_operator_override_are_not_equal()
        {
            var sn1A = new SystemName("54321");
            var sn2A = new SystemName("54321");
            Check.That(sn1A != sn2A).IsFalse();
        }

        [TestMethod]
        public void Test_SystemName_not_equal_operator_override_null_values()
        {
            var sn1A = new SystemName("12345");
            SystemName sn2A = null;
            Check.That(sn1A != sn2A).IsTrue();
            Check.That(sn2A != sn1A).IsTrue();
        }

        #region Test Equals Hash Override
        [TestMethod]
        public void Test_SystemName_Equals_override_are_equal()
        {
            var sn1A = new SystemName("12345");
            var sn2A = new SystemName("12345");
            Check.That(sn1A.Equals(sn2A)).IsTrue();
            Check.That(sn1A).Equals(sn2A);
        }

        [TestMethod]
        public void Test_SystemName_Equals_override_are_not_equal()
        {
            var sn1A = new SystemName("12345");
            var sn2A = new SystemName("54321");
            Check.That(sn1A.Equals(sn2A)).IsFalse();
        }

        [TestMethod]
        public void Test_SystemName_Equals_override_null_values()
        {
            var sn1A = new SystemName("12345");
            SystemName sn2A = null;
            Check.That(sn1A.Equals(sn2A)).IsFalse();
        }

        [TestMethod]
        public void Test_SystemName_GetHashCode()
        {
            var sn1A = new SystemName("12345");
            var sn2A = new SystemName("65498");
            Check.That(sn1A.GetHashCode()).IsEqualTo("12345".GetHashCode());
            Check.That(sn2A.GetHashCode()).IsEqualTo("65498".GetHashCode());
        }
        #endregion

    }
}
