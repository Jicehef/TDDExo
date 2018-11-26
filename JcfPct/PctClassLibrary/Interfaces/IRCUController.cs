using PctClassLibrary.Interfaces;

namespace PctClassLibrary.RCU.Type1
{
    public interface IRCUController
    {
        void AddDevice(IDevice device);

        RcuObjectInstance GetObjectInstance(RcuObject rcuObject);
    }
}