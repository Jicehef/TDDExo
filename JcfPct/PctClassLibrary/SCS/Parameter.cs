using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Value;

namespace PctClassLibrary.SCS
{
    public class Parameter: ValueType<Parameter>
    {
        private readonly string _name;
        private readonly string _value;

        public Parameter(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public string Value
        {
            get
            {
                return _value;
            }
        }

        public string Name
        {
            get { return _name; }
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            // we decorate our standard HashSet with the SetByValue helper class.
            return new List<object>() { this._name, this._value };
        }

    }
}
