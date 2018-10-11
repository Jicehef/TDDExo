using System.Collections.Immutable;
using System.Linq;

namespace JcfPctClassLibrary.SCS
{
    public class Unit
    {
        private KeyObject _selectedKeyObject;
        public KeyObject SelectedKeyObject => _selectedKeyObject;
        public readonly ImmutableList<KeyObject> CanDoKeyObjects;

        public Unit(ImmutableList<KeyObject> canDoKeyObjects)
        {
            this.CanDoKeyObjects = canDoKeyObjects;
        }

        public bool SelectKeyObject(KeyObject toSelect)
        {
            var x = CanDoKeyObjects.FirstOrDefault(o => o.Name == toSelect.Name);
            _selectedKeyObject = x;
            return x != null;
        }

        public void ResetSelectedKeyObject()
        {
            _selectedKeyObject = null;
        }

    }
}
