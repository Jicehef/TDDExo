namespace PctClassLibrary.RCU
{
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