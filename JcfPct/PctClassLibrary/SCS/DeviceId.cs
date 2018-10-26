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
            if (IsValidId(deviceId))
            {
                return deviceId;
            }
            else
            {
                throw new System.ArgumentException("Device BusID is invalid", deviceId);
            }
        }

        public static bool IsValidId(string id)
        {
            string pattern = @"^[0-9a-fA-F]{8}$";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(id);
            return match.Success;
        }
    }
}
