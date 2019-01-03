namespace PctClassLibrary.RCU
{
    public class RcuObjectInstance
    {
        public RcuFunctionnalObject RcuFunctionnalObject { get; set; }
        public int InstanceNumber { get; set; }

        public RcuObjectInstance(RcuFunctionnalObject rcuFunctionnalObject, int instanceNumber)
        {
            RcuFunctionnalObject = rcuFunctionnalObject;
            InstanceNumber = instanceNumber;
        }
    }
}