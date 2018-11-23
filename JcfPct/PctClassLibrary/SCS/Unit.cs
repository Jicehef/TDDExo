using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace PctClassLibrary.SCS
{
    public class Unit
    {
        private KeyObject _keyObject;
        public KeyObject KeyObject => _keyObject;
        public readonly ListOfKeyObjects CanDoKeyObjects;

        public Unit(ListOfKeyObjects canDoKeyObjects)
        {

            this.CanDoKeyObjects = canDoKeyObjects;
            _keyObject = canDoKeyObjects.GetFirstItem();
        }

        public bool SelectKeyObject(KeyObject toSelect)
        {
            bool isInList = CanDoKeyObjects.Contains(toSelect);
            _keyObject = isInList ? toSelect : _keyObject;
            return isInList;
        }

        public void ResetKeyObject()
        {
            _keyObject = CanDoKeyObjects.GetFirstItem();
        }

    }
}
