using System.Collections.Generic;
using System.Linq;
using PctClassLibrary.Common;
using PctClassLibrary.Interfaces;

namespace PctClassLibrary.RCU.Type1
{
    public class RcuController : IRCUController
    {
        private readonly RoomControllerUnit _roomControllerUnit;
        private List<DeviceTechnology> _deviceTechnologies = new List<DeviceTechnology>();
        private List<AvailableObjectInstance> _availableObjectInstances;

        public RcuController(RoomControllerUnit roomControllerUnit)
        {
            _roomControllerUnit = roomControllerUnit;
            LoadAvailableObjectInstances();
        }

        public void AddDevice(IDevice device)
        {
            if (!_roomControllerUnit.IsTechnologyValid(device.TechnologyType))
            {
                throw new System.ArgumentException("Device Technology not compatible");
            }
            var list = GetDeviceTechnology(device);
            list.AddDevice(device);
        }

        public DeviceTechnology GetDevices4Technology(Definition.TechnologyType technology)
        {
            return _deviceTechnologies.FirstOrDefault(d => d.Technology == technology);
        }

        public RcuObjectInstance GetObjectInstance(RcuFunctionnalObject rcuFunctionnalObject)
        {
            var objectInstance = GetAvailable(rcuFunctionnalObject);
            return objectInstance?.BookRcuObjectInstance();
        }

        private DeviceTechnology GetDeviceTechnology(IDevice device)
        {
            var deviceTechnologies = _deviceTechnologies.Where(d => d.Technology == device.TechnologyType);
            return !deviceTechnologies.Any() ? CreateDeviceTechnology(device) : deviceTechnologies.First();
        }

        private DeviceTechnology CreateDeviceTechnology(IDevice device)
        {
            var technology = new DeviceTechnology(device.TechnologyType);
            _deviceTechnologies.Add(technology);
            return technology;
        }

        private AvailableObjectInstance GetAvailable(RcuFunctionnalObject rcuFunctionnalObject)
        {
            var objectInstances =
                _availableObjectInstances.Where(o => o.RcuFunctionnalObject == rcuFunctionnalObject && o.IsAvailable);
            return objectInstances.Any() ? objectInstances.First() : null;
        }

        private void LoadAvailableObjectInstances()
        {
            _availableObjectInstances = new List<AvailableObjectInstance>();
            foreach (var groupRcuObject in _roomControllerUnit.GetRcuObjects().GroupBy(o => o.GetName()))
            {
                var index = 0;
                foreach (var rcuObject in groupRcuObject)
                {
                    _availableObjectInstances.Add(new AvailableObjectInstance(new RcuObjectInstance(rcuObject, index)));
                    index++;
                }
            }
        }
    }
}