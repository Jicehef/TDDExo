namespace PctClassLibrary.SCS
{
    public class KeyObject
    {
        private readonly string _name;

        public KeyObject(string name)
        {
            this._name = name;
        }
        public string Name => _name;

        public static bool operator == (KeyObject ko1, KeyObject ko2)
        {
            if (object.ReferenceEquals(ko1, null))
            {
                return object.ReferenceEquals(ko2, null);
            }

            if (object.ReferenceEquals(ko2, null))
            {
                return false;
            }

            return ko1.Name == ko2.Name;
        }

        public static bool operator != (KeyObject ko1, KeyObject ko2)
        {
            if (object.ReferenceEquals(ko1, null))
            {
                return !object.ReferenceEquals(ko2, null);
            }

            if (object.ReferenceEquals(ko2, null))
            {
                return true;
            }

            return ko1.Name != ko2.Name;
        }

        public override bool Equals(object obj)
        {
            var item = obj as KeyObject;

            if (item == null)
            {
                return false;
            }

            return this.Name.Equals(item.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
