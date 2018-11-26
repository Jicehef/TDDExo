using NFluent;
using NUnit.Framework;
using PctClassLibrary.Common;
using PctClassLibrary.Mechanical;

namespace PctClassLibraryUnitTest.Mechanical
{
    public class SingleInputShould
    {
        [Test]
        public void Accept_and_retrieve_a_valid_name()
        {
            var sn = new SystemName("mySingleInput");
            var x = new SingleInput(sn);
            Check.That(x.SystemName.Value).IsEqualTo("mySingleInput");
        }

        [Test]
        public void Rename_and_retrieve_a_valid_name()
        {
            var sn = new SystemName("mySingleInput");
            var x = new SingleInput(sn);
            x.SystemName = new SystemName("NewName");
            Check.That(x.SystemName.Value).IsEqualTo("NewName");
        }
    }
}
