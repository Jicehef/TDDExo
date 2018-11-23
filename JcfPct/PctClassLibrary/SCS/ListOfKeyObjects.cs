using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Value;

namespace PctClassLibrary.SCS
{
    public class ListOfKeyObjects : ValueType<ListOfKeyObjects>
    {
        private readonly HashSet<KeyObject> _keyObjects;

        public ListOfKeyObjects(List<KeyObject> keyObjects)
        {
            if (!keyObjects.Any())
            {
                throw new System.ArgumentException("Empty list of KeyObjects invalid");
            }

            this._keyObjects = new HashSet<KeyObject>();
            foreach (var keyObject in keyObjects)
            {
                this._keyObjects.Add(keyObject);
            }
        }

        public KeyObject GetFirstItem()
        {
            return _keyObjects.First();
        }

        public int Count()
        {
            return this._keyObjects.Count();
        }

        public bool Contains(KeyObject keyObject)
        {
            var x = this._keyObjects.FirstOrDefault(o => o == keyObject);
            return x != null;
        }

        public List<KeyObject> ToList()
        {
            var listOfKeyObjects = new List<KeyObject>();
            foreach (var keyObject in _keyObjects)
            {
                listOfKeyObjects.Add(keyObject);
            }

            return listOfKeyObjects;
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            // we decorate our standard HashSet with the SetByValue helper class.
            return new List<object>() { new SetByValue<KeyObject>(this._keyObjects) };
        }
    }
}
