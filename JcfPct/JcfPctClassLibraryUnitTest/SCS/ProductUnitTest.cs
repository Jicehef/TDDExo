﻿using System;
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
        List<Unit> units = new List<Unit>();
        Dictionary<string, KeyObject> keyObjects =new Dictionary<string, KeyObject>();

        [TestInitialize]
        public void Test_Init()
        {
            List<String> koNames = new List<string>(){"123", "234", "345", "456", "567","678"};
            foreach (var koName in koNames)
            {
                keyObjects.Add(koName, new KeyObject(koName));
            }
            units.Add(new Unit(ImmutableList.Create<KeyObject>(keyObjects.ElementAt(0).Value)));
            units.Add(new Unit(ImmutableList.Create<KeyObject>(keyObjects.ElementAt(1).Value)));
            units.Add(new Unit(ImmutableList.Create<KeyObject>(keyObjects.ElementAt(2).Value, keyObjects.ElementAt(4).Value)));
            units.Add(new Unit(ImmutableList.Create<KeyObject>(keyObjects.ElementAt(3).Value, keyObjects.ElementAt(5).Value)));
        }

        [TestMethod]
        public void Test_created_Product_is_of_correct_type()
        {
            var product = new Product(new List<Unit>());
            Check.That(product).IsInstanceOf<Product>();
        }

        [TestMethod]
        public void Test_number_of_Units_in_product_is_conform_to_given_parameter()
        {
            var product = new Product(units);
            Check.That(product.Units.Count()).IsEqualTo(units.Count());
        }

        [TestMethod]
        public void Test_we_can_select_a_valid_ko_for_a_unit()
        {
            var product = new Product(units);
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
            var product = new Product(units);
            Check.That(product.SelectKeyObject4Unit(keyObjects.ElementAt(0).Value, 1)).IsFalse();
            Check.That(product.SelectKeyObject4Unit(keyObjects.ElementAt(1).Value, 2)).IsFalse();
            Check.That(product.SelectKeyObject4Unit(keyObjects.ElementAt(5).Value, 2)).IsFalse();
        }

        [TestMethod]
        public void Test_the_selected_value_is_valid_ko_for_a_unit()
        {
            var product = new Product(units);
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

    }
}
