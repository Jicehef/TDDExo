using System;

namespace JcfPctClassLibrary.SCS
{
    public class KeyObject
    {
        private readonly string _name;

        public KeyObject(string name)
        {
            this._name = name;
        }
        public string Name => _name;
    }
}
