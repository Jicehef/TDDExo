using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PctClassLibrary.SCS
{
    public class DeviceId
    {
       private const string DeviceIdPattern = @"^[0-9a-fA-F]{8}$";
       private string _deviceId;

        public string Value
        {
            get => _deviceId;
            set => _deviceId = SetDeviceId(value);
        }

        public DeviceId(string deviceId)
        {
            _deviceId = SetDeviceId(deviceId);
        }

        private string SetDeviceId(string deviceId)
        {
            if (IsValid(deviceId))
            {
                return deviceId;
            }
            else
            {
                throw new System.ArgumentException("Device BusID is invalid", deviceId);
            }
        }

        public static bool IsValid(string id)
        {
            Regex regex = new Regex(DeviceIdPattern);
            Match match = regex.Match(id);
            return match.Success;
        }

        public static bool operator ==(DeviceId id1, DeviceId id2)
        {
            if (object.ReferenceEquals(id1, null))
            {
                return object.ReferenceEquals(id2, null);
            }

            if (object.ReferenceEquals(id2, null))
            {
                return false;
            }

            return id1.Value == id2.Value;
        }

        public static bool operator !=(DeviceId id1, DeviceId id2)
        {
            if (object.ReferenceEquals(id1, null))
            {
                return !object.ReferenceEquals(id2, null);
            }

            if (object.ReferenceEquals(id2, null))
            {
                return true;
            }

            return id1.Value != id2.Value;
        }

        public override bool Equals(object obj)
        {
            var item = obj as DeviceId;

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
