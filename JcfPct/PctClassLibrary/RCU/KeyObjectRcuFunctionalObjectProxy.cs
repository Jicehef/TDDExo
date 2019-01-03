using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PctClassLibrary.RCU.Type1;
using PctClassLibrary.SCS;

namespace PctClassLibrary.RCU
{
    public class KeyObjectRcuFunctionalObjectProxy
    {
        private Dictionary<KeyObject, RcuFunctionalObject> _proxy;

        public KeyObjectRcuFunctionalObjectProxy(Dictionary<KeyObject, RcuFunctionalObject> proxy)
        {
            _proxy = proxy;
        }

        public RcuFunctionalObjectInstance GetObjectInstance(KeyObject keyObject, IRCUController rcuController)
        {
            if (_proxy.ContainsKey(keyObject))
            {
                return rcuController.GetObjectInstance(_proxy[keyObject]);
            }

            throw new System.ArgumentException($"KeyObject {keyObject.Name} not compatible with RCU");
        }
    }
}
