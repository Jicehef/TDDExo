using System.Collections.Generic;
using PctClassLibrary.Common;
using PctClassLibrary.Interfaces;

namespace PctClassLibrary.SCS
{
    public class Device: IDevice
    {
        // todo public readonly or private with GetUnit method ??
        public readonly  Unit[] Units;
        public readonly ScsId BusId;
        public SystemName SystemName { get; set; }

        private Definition.TechnologyType _technologyType;
        public Definition.TechnologyType TechnologyType => _technologyType;  

        public Device(SystemName systemName, ScsId id, Unit[] units)
        {
            this._technologyType = Definition.TechnologyType.SCS;
            this.SystemName = systemName;
            this.BusId = id;
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

            return Units[unitNumber].KeyObject;
        }
        
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

    }
}
