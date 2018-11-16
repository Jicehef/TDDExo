using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Value;

namespace PctClassLibrary.SCS
{
    public class ScsId: ValueType<ScsId>
    {
       private const string DeviceIdPattern = @"^[0-9a-fA-F]{8}$";
       private string _scsId;

        public string Value
        {
            get => _scsId;
        }

        public ScsId(string deviceId)
        {
            _scsId = SetDeviceId(deviceId);
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

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            // we decorate our standard HashSet with the SetByValue helper class.
            return new List<object>() {this._scsId };
        }

    }
}
