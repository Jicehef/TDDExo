using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Value;

namespace PctClassLibrary.Common
{
    public class SystemName : ValueType<SystemName>
    {
        private string _systemName;
        private const string SytemNamePattern = @"^[0-9a-zA-Z_-]{4,20}$";

        public string Value { get => _systemName; set => _systemName = value; }

        public SystemName(string name = "NoName")
        {
            _systemName = name;
        }

        public static bool IsValid(string systemName)
        {
            Regex regex = new Regex(SytemNamePattern);
            Match match = regex.Match(systemName);
            return match.Success;
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            // we decorate our standard HashSet with the SetByValue helper class.
            return new List<object>() { this._systemName };
        }

    }
}
