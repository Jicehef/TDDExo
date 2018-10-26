using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using PctClassLibrary.SCS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace JcfPctClassLibraryUnitTest.SCS
{
    [TestClass]
    public class ProductUnitTest
    {
        Unit[] units = new Unit[4];
        DeviceId deviceId = new DeviceId("12345678");
        Dictionary<string, KeyObject> keyObjects = new Dictionary<string, KeyObject>();

        [TestInitialize]
        public void Test_Init()
        {
            List<String> koNames = new List<string>() {"123", "234", "345", "456", "567", "678"};
            foreach (var koName in koNames)
            {
                keyObjects.Add(koName, new KeyObject(koName));
            }

            units[0] = new Unit(ImmutableList.Create<KeyObject>(keyObjects.ElementAt(0).Value));
            units[1] = new Unit(ImmutableList.Create<KeyObject>(keyObjects.ElementAt(1).Value));
            units[2] = new Unit(ImmutableList.Create<KeyObject>(keyObjects.ElementAt(2).Value,
                keyObjects.ElementAt(4).Value));
            units[3] = new Unit(ImmutableList.Create<KeyObject>(keyObjects.ElementAt(3).Value,
                keyObjects.ElementAt(5).Value));
        }

        [TestMethod]
        public void Test_created_Product_is_of_correct_type()
        {
            var product = new Product(deviceId, new Unit[1]);
            Check.That(product).IsInstanceOf<Product>();
        }

        [TestMethod]
        public void Test_created_Product_has_correct_id()
        {
            var product = new Product(deviceId, new Unit[1]);
            Check.That(product.BusID).IsEqualTo(deviceId);
            Check.That(product.BusID.Value).IsEqualTo("12345678");
        }

        [TestMethod]
        public void Test_number_of_Units_in_product_is_conform_to_given_parameter()
        {
            var product = new Product(deviceId, units);
            Check.That(product.Units.Count()).IsEqualTo(units.Count());
        }

        [TestMethod]
        public void Test_we_can_select_a_valid_ko_for_a_unit()
        {
            var product = new Product(deviceId, units);
            for (var i = 0; i < 4; i++)
            {
                var result = product.SelectKeyObject4Unit(keyObjects.ElementAt(i).Value, i);
                Check.That(result).IsTrue();
            }

            Check.That(product.SelectKeyObject4Unit(keyObjects.ElementAt(4).Value, 2)).IsTrue();
            Check.That(product.SelectKeyObject4Unit(keyObjects.ElementAt(5).Value, 3)).IsTrue();
        }

        [TestMethod]
        public void Test_we_can_not_select_an_invalid_ko_for_a_unit()
        {
            var product = new Product(deviceId, units);
            Check.That(product.SelectKeyObject4Unit(keyObjects.ElementAt(0).Value, 1)).IsFalse();
            Check.That(product.SelectKeyObject4Unit(keyObjects.ElementAt(1).Value, 2)).IsFalse();
            Check.That(product.SelectKeyObject4Unit(keyObjects.ElementAt(5).Value, 2)).IsFalse();
        }

        [TestMethod]
        public void Test_the_selected_value_is_valid_ko_for_a_unit()
        {
            var product = new Product(deviceId, units);
            for (var i = 0; i < 4; i++)
            {
                product.SelectKeyObject4Unit(keyObjects.ElementAt(i).Value, i);
                var result = product.GetKeyObject4Unit(i);
                Check.That(result == keyObjects.ElementAt(i).Value).IsTrue();
            }

            product.SelectKeyObject4Unit(keyObjects.ElementAt(4).Value, 2);
            var result2 = product.GetKeyObject4Unit(2);
            Check.That(result2 == keyObjects.ElementAt(4).Value).IsTrue();

            product.SelectKeyObject4Unit(keyObjects.ElementAt(5).Value, 3);
            var result3 = product.GetKeyObject4Unit(3);
            Check.That(result3 == keyObjects.ElementAt(5).Value).IsTrue();
        }

        [TestMethod]
        public void Test_for_GetKeyObject4Unit_when_unit_index_is_out_of_bounds_an_exception_is_raised()
        {
            var product = new Product(deviceId, units);
            Check.ThatCode(() =>
            {
                var result = product.GetKeyObject4Unit(10);
            }).Throws<System.ArgumentException>();
        }

        [TestMethod]
        public void Test_for_SelectKeyObject4Unit_when_unit_index_is_out_of_bounds_an_exception_is_raised()
        {
            var product = new Product(deviceId, units);
            Check.ThatCode(() =>
            {
                var result = product.SelectKeyObject4Unit(keyObjects.ElementAt(4).Value, 10);
            }).Throws<System.ArgumentException>();
        }
    }
}