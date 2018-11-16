using System.Collections.Generic;
using Value;

namespace PctClassLibrary.SCS
{
    public class KeyObject : ValueType<KeyObject>
    {
        private readonly string _name;

        public KeyObject(string name)
        {
            this._name = name;
        }
        public string Name => _name;

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            // we decorate our standard HashSet with the SetByValue helper class.
            return new List<object>() {this._name };
        }
    }
}
