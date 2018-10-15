using System.Collections.Generic;

namespace JcfPctClassLibrary.SCS
{
    public class Product
    {
        public readonly  List<Unit> Units;

        public Product(List<Unit> units)
        {
            this.Units = units;
        }

        public bool SelectKeyObject4Unit(KeyObject ko, int unitNumber)
        {
            // todo what to do when out of bounds ??
            return Units[unitNumber].SelectKeyObject(ko);
        }
    }
}
