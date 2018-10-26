using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PctClassLibrary.Common
{
    public class SystemName
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

        public static bool operator ==(SystemName sn1, SystemName sn2)
        {
            if (object.ReferenceEquals(sn1, null))
            {
                return object.ReferenceEquals(sn2, null);
            }

            if (object.ReferenceEquals(sn2, null))
            {
                return false;
            }

            return sn1.Value == sn2.Value;
        }

        public static bool operator !=(SystemName sn1, SystemName sn2)
        {
            if (object.ReferenceEquals(sn1, null))
            {
                return !object.ReferenceEquals(sn2, null);
            }

            if (object.ReferenceEquals(sn2, null))
            {
                return true;
            }

            return sn1.Value != sn2.Value;
        }

        public override bool Equals(object obj)
        {
            var item = obj as SystemName;

            if (item == null)
            {
                return false;
            }

            return this.Value.Equals(item.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

    }
}
