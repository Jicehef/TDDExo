using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PctClassLibrary.Common;

namespace PctClassLibrary.RCU.Type1
{
    public class RoomControllerUnit
    {
        public readonly Definition.TechnologyType TechnologyType;
        public DeviceTechnology SCSDevices = new DeviceTechnology(Definition.TechnologyType.SCS);
        public DeviceTechnology mecaDevices = new DeviceTechnology(Definition.TechnologyType.Mecanical);

        public RoomControllerUnit(Definition.TechnologyType technoType)
        {
            TechnologyType = technoType;
        }

    }
}
