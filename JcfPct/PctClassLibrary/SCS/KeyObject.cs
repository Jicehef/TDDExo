using PctClassLibrary.Common.DesignPattern;

namespace PctClassLibrary.SCS
{
    public class KeyObject : ValueObject<KeyObject>
    {
        private readonly string _name;

        public KeyObject(string name)
        {
            this._name = name;
        }
        public string Name => _name;

        protected override bool EqualsCore(KeyObject other)
        {
            return _name == other.Name;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                return this.Name.GetHashCode();
            }
        }
    }
}
