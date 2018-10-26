using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PctClassLibrary.Common;
using PctClassLibrary.Interfaces;

namespace PctClassLibrary.Mechanical
{
    public class SingleInput: IDeviceInterface
    {
        public SystemName SystemName { get; set; }

        public SingleInput(string name)
        {
            SystemName = new SystemName(name);
        }
    }
}
