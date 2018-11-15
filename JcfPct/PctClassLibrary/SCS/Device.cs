﻿using System.Collections.Generic;
using PctClassLibrary.Common;
using PctClassLibrary.Interfaces;

namespace PctClassLibrary.SCS
{
    public class Device: IDeviceInterface
    {
        // todo public readonly or private with GetUnit method ??
        public readonly  Unit[] Units;
        public readonly ScsId BusID;

        private string _systemIdentificator;


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
        public Device(SystemName systemName, ScsId ID, Unit[] units)
        {
            this.SystemName = systemName;
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

        public SystemName SystemName { get; set; }
    }
}
