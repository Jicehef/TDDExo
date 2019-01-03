using PctClassLibrary.Interfaces;

namespace PctClassLibrary.RCU.Type1
{
    public interface IRCUController
    {
        void AddDevice(IDevice device);

        RcuFunctionalObjectInstance GetObjectInstance(RcuFunctionalObject rcuFunctionalObject);
    }
}