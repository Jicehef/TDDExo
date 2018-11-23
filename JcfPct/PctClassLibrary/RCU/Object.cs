using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PctClassLibrary.SCS;
using Value;

namespace PctClassLibrary.RCU.Type1
{
    public interface IObject
    {
    }

    public class Object: ValueType<Object>, IObject
    {
        private readonly string _name;
        private readonly string _rcuType;
        private List<Parameter> _parameters;

        public Object(string name, string rcuType, List<Parameter> parameters)
        {
            _name = name;
            _rcuType = rcuType;
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            // we decorate our standard HashSet with the SetByValue helper class.
            return new List<object>() { this._name, this._rcuType };
        }

    }
}
