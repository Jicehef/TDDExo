using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PctClassLibrary.Interfaces;

namespace PctClassLibrary.Common
{
    public class DeviceTechnology: ITechnology
    {
        public List<IDevice> Devices = new List<IDevice>();

        public DeviceTechnology(Definition.TechnologyType technology)
        {
            Technology = technology;
        }

        public Definition.TechnologyType Technology { get; set; }

        public void AddDevice(IDevice device)
        {
            Devices.Add(device);
        }
    }
}
