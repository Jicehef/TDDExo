using System;
using NFluent;
using NUnit.Framework;
using PctClassLibrary.SCS;

namespace PctClassLibraryUnitTest.SCS
{
    public class ParameterShould
    {
        [Test]
        public void Create_object_of_correct_type()
        {
            var parameter = new Parameter("Name1", "Value1");
            Check.That(parameter).IsInstanceOf<Parameter>();
        }

        [Test]
        public void Store_and_retrieve_a_correct_name()
        {
            const string name = "ParamName";
            const string value = "490";
            var parameter = new Parameter(name, value);
            Check.That(parameter.Name).Equals(name);

        }
        [Test]
        public void Store_and_retrieve_a_correct_value()
        {
            const string name = "ParamName";
            const string value = "490";
            var parameter = new Parameter(name, value);
            Check.That(parameter.Value).Equals(value);

        }

        #region Test Operator Override
        [Test]
        public void Be_equal_with_same_values()
        {
            var parameter1 = new Parameter("name","123");
            var parameter2 = new Parameter("name", "123");
            Check.That(parameter2 == parameter1).IsTrue();
        }

        [Test]
        public void Not_be_equal_with_different_values()
        {
            var parameter1 = new Parameter("name", "123");
            var parameter2 = new Parameter("name", "1234");
            Check.That(parameter2 == parameter1).IsFalse();
        }

        [Test]
        public void Not_be_equal_with_null_values()
        {
            var parameter1 = new Parameter("name", "123");
            Parameter parameter2 = null;
            Check.That(parameter1 == parameter2).IsFalse();
            Check.That(parameter2 == parameter1).IsFalse();
        }

        [Test]
        public void Be_different_with_different_values()
        {
            var parameter1 = new Parameter("name", "123");
            var parameter2 = new Parameter("name", "1234");
            Check.That(parameter1 != parameter2).IsTrue();
        }
        [Test]
        public void Be_different_with_different_vnameses()
        {
            var parameter1 = new Parameter("name1", "123");
            var parameter2 = new Parameter("name2", "123");
            Check.That(parameter1 != parameter2).IsTrue();
        }

        [Test]
        public void Not_be_different_with_same_values()
        {
            var parameter1 = new Parameter("name", "123");
            var parameter2 = new Parameter("name", "123");
            Check.That(parameter1 != parameter2).IsFalse();
        }
        #endregion

        #region Test Equals Hash Override
        [Test]
        public void Have_equals_true_with_same_values()
        {
            var parameter1 = new Parameter("name", "123");
            var parameter2 = new Parameter("name", "123");
            Check.That(parameter1.Equals(parameter2)).IsTrue();
            Check.That(parameter1).Equals(parameter2);
        }

        [Test]
        public void Have_equals_false_with_different_values()
        {
            var parameter1 = new Parameter("name", "123");
            var parameter2 = new Parameter("name", "1234");
            Check.That(parameter1.Equals(parameter2)).IsFalse();
        }

        [Test]
        public void Not_Equals_with_null_values()
        {
            var parameter1 = new Parameter("name", "123");
            Parameter parameter2 = null;
            Check.That(parameter1.Equals(parameter2)).IsFalse();
        }
        #endregion

    }
}
