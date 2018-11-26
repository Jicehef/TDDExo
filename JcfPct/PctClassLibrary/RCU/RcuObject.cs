﻿using System.Collections.Generic;
using Value;

namespace PctClassLibrary.RCU
{

    public class RcuObject: ValueType<RcuObject>
    {
        private readonly string _name;
        private readonly string _referenceNumber;

        public RcuObject(string name, string referenceNumber)
        {
            _name = name;
            _referenceNumber = referenceNumber;
        }

        public string GetName()
        {
            return _name;
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            // we decorate our standard HashSet with the SetByValue helper class.
            return new List<object>() { this._name, this._referenceNumber };
        }

    }
}
