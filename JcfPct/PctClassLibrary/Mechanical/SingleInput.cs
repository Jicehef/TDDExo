using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PctClassLibrary.Common;
using PctClassLibrary.Interfaces;

namespace PctClassLibrary.Mechanical
{
    public class SingleInput: IDevice
    {
        public SystemName SystemName { get; set; }

        private Definition.TechnologyType _technologyType;
        public Definition.TechnologyType TechnologyType => _technologyType;


        public SingleInput(SystemName systemName)
        {
            _technologyType = Definition.TechnologyType.Mecanical;
            SystemName = systemName;
        }
    }
}
