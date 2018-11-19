using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace PctClassLibrary.SCS
{
    public class Unit
    {
        private KeyObject _selectedKeyObject;
        public KeyObject SelectedKeyObject => _selectedKeyObject;
        public readonly ListOfKeyObjects CanDoKeyObjects;

        public Unit(ListOfKeyObjects canDoKeyObjects)
        {

            this.CanDoKeyObjects = canDoKeyObjects;
            _selectedKeyObject = canDoKeyObjects.GetFirstItem();
        }

        public bool SelectKeyObject(KeyObject toSelect)
        {
            bool isInList = CanDoKeyObjects.IsInList(toSelect);
            _selectedKeyObject = isInList ? toSelect : _selectedKeyObject;
            return isInList;
        }

        public void ResetSelectedKeyObject()
        {
            _selectedKeyObject = CanDoKeyObjects.GetFirstItem();
        }

    }
}
