namespace PctClassLibrary.RCU
{
    public class RcuFunctionalObjectInstance
    {
        public RcuFunctionalObject RcuFunctionalObject { get; set; }
        public int InstanceNumber { get; set; }

        public RcuFunctionalObjectInstance(RcuFunctionalObject rcuFunctionalObject, int instanceNumber)
        {
            RcuFunctionalObject = rcuFunctionalObject;
            InstanceNumber = instanceNumber;
        }
    }
}