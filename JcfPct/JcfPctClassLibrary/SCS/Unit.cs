using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace JcfPctClassLibrary.SCS
{
    public class Unit
    {
        private KeyObject SelectedKeyObject;
        public readonly ImmutableList<KeyObject> CanDoKeyObjects;

        public Unit(ImmutableList<KeyObject> canDoKeyObjects)
        {
            this.CanDoKeyObjects = canDoKeyObjects;
        }
    }
}
