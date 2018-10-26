using System.Collections.Generic;

namespace PctClassLibrary.SCS
{
    public class Product
    {
        // todo public readonly or private with GetUnit method ??
        public readonly  Unit[] Units;
        public readonly DeviceId BusID;

        private bool IsWithinUnitsBounds(int index)
        {
            if (index < 0 || index >= this.Units.Length)
            {
                return false;
            }

            return true;
        }

        private void CheckBounding(int unitNumber)
        {
            if (!IsWithinUnitsBounds(unitNumber))
            {
                throw new System.ArgumentException("Unit number is invalid", unitNumber.ToString());
            }
        }
        public Product(DeviceId ID, Unit[] units)
        {
            this.BusID = ID;
            this.Units = units;
        }

        public bool SelectKeyObject4Unit(KeyObject ko, int unitNumber)
        {
            // todo what to do when out of bounds ??
            CheckBounding(unitNumber);

            return Units[unitNumber].SelectKeyObject(ko);
        }


        public KeyObject GetKeyObject4Unit(int unitNumber)
        {
            // todo what to do when out of bounds ??
            CheckBounding(unitNumber);

            return Units[unitNumber].SelectedKeyObject;
        }
    }
}
