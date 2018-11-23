using System.Collections.Generic;
using System.Text.RegularExpressions;
using Value;

namespace PctClassLibrary.SCS
{
    public class KeyObject : ValueType<KeyObject>
    {
        private const string NamePattern = @"^[0-9]{3}$";
        private readonly string _name;

        public KeyObject(string name)
        {
            this._name = SetName(name);
        }

        public string Name => _name;

        private string SetName(string name)
        {
            if (IsValid(name))
            {
                return name;
            }
            else
            {
                throw new System.ArgumentException("KeyObject name is invalid", name);
            }
        }

        public static bool IsValid(string id)
        {
            Regex regex = new Regex(NamePattern);
            Match match = regex.Match(id);
            return match.Success;
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            // we decorate our standard HashSet with the SetByValue helper class.
            return new List<object>() {this._name };
        }
    }
}
