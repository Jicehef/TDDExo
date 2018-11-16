using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Value;

namespace PctClassLibrary.SCS
{
    public class ListOfKeyObjects : ValueType<ListOfKeyObjects>
    {
        private readonly HashSet<KeyObject> _keyObjects;

        public ListOfKeyObjects(List<KeyObject> keyObjects)
        {
            this._keyObjects = new HashSet<KeyObject>();
            foreach (var keyObject in keyObjects)
            {
                this._keyObjects.Add(keyObject);
            }
        }

        public bool IsInList(KeyObject keyObject)
        {
            var x = this._keyObjects.FirstOrDefault(o => o == keyObject);
            return x != null;
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            // we decorate our standard HashSet with the SetByValue helper class.
            return new List<object>() { new SetByValue<KeyObject>(this._keyObjects) };
        }
    }
}
