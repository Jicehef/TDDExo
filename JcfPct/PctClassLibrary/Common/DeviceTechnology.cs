using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PctClassLibrary.Interfaces;

namespace PctClassLibrary.Common
{
    public class DeviceTechnology: ITechnologyInterface
    {
        public List<IDeviceInterface> Devices = new List<IDeviceInterface>();

        public DeviceTechnology(Definition.TechnologyType technology)
        {
            Technology = technology;
        }

        public Definition.TechnologyType Technology { get; set; }

        public void AddDevice(IDeviceInterface device)
        {
            Devices.Add(device);
        }
    }
}
