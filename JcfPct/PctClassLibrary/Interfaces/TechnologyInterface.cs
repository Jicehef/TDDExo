using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PctClassLibrary.Common;

namespace PctClassLibrary.Interfaces
{
    public interface ITechnologyInterface
    {
        Definition.TechnologyType Technology { get; set; }

        void AddDevice(IDeviceInterface device);
    }
}
