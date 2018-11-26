using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PctClassLibrary.RCU.Type1;
using PctClassLibrary.SCS;

namespace PctClassLibrary.RCU
{
    public class KeyObjectRcuObjectProxy
    {
        private Dictionary<KeyObject, RcuObject> _proxy;

        public KeyObjectRcuObjectProxy(Dictionary<KeyObject, RcuObject> proxy)
        {
            _proxy = proxy;
        }

        public RcuObjectInstance GetObjectInstance(KeyObject keyObject, IRCUController rcuController)
        {
            if (_proxy.ContainsKey(keyObject))
            {
                return rcuController.GetObjectInstance(_proxy[keyObject]);
            }

            throw new System.ArgumentException($"KeyObject {keyObject.Name} not compatible with RCU");
        }
    }

    public class RcuObjectInstance
    {
        public RcuObject RcuObject { get; set; }
        public int InstanceNumber { get; set; }

        public RcuObjectInstance(RcuObject rcuObject, int instanceNumber)
        {
            RcuObject = rcuObject;
            InstanceNumber = instanceNumber;
        }
    }
}
