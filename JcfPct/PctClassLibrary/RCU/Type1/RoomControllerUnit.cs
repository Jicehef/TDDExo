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
        private readonly List<RcuObject> _objects;
        private readonly List<Definition.TechnologyType> _technologyTypes;

        public RoomControllerUnit(List<RcuObject> objects, List<Definition.TechnologyType> technologyTypes)
        {
            _objects = objects;
            _technologyTypes = technologyTypes;
        }

        public bool IsTechnologyValid(Definition.TechnologyType technologyType)
        {
            return _technologyTypes.Any(tt => tt == technologyType);
        }

        public IEnumerable<RcuObject> GetRcuObjects()
        {
            return _objects;
        }
    }
}
