namespace PctClassLibrary.RCU.Type1
{
    internal class AvailableObjectInstance
    {
        private RcuFunctionalObjectInstance _functionalObjectInstance;

        private bool _availability;

        public bool IsAvailable => _availability;
        public RcuFunctionalObject RcuFunctionalObject => _functionalObjectInstance.RcuFunctionalObject;

        public AvailableObjectInstance(RcuFunctionalObjectInstance functionalObjectInstance, bool availability = true)
        {
            _functionalObjectInstance = functionalObjectInstance;
            _availability = availability;
        }

        public void Release()
        {
            _availability = true;
        }

        public RcuFunctionalObjectInstance BookRcuFunctionalObjectInstance()
        {
            SetUnavailable();
            return _functionalObjectInstance;
        }

        private void SetUnavailable()
        {
            _availability = false;
        }
    }
}