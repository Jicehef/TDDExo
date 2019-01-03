namespace PctClassLibrary.RCU.Type1
{
    internal class AvailableObjectInstance
    {
        private RcuObjectInstance _objectInstance;

        private bool _availability;

        public bool IsAvailable => _availability;
        public RcuFunctionnalObject RcuFunctionnalObject => _objectInstance.RcuFunctionnalObject;

        public AvailableObjectInstance(RcuObjectInstance objectInstance, bool availability = true)
        {
            _objectInstance = objectInstance;
            _availability = availability;
        }

        public void Release()
        {
            _availability = true;
        }

        public RcuObjectInstance BookRcuObjectInstance()
        {
            SetUnavailable();
            return _objectInstance;
        }

        private void SetUnavailable()
        {
            _availability = false;
        }
    }
}