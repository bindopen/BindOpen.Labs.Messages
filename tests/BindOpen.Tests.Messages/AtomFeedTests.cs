using NUnit.Framework;

namespace BindOpen.Tests.Messages
{
    [TestFixture, Order(401)]
    public class AtomFeedTests
    {
        private readonly string _filePath = GlobalVariables.WorkingFolder + "Log.xml";

        private dynamic _testData;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [Test, Order(1)]
        public void LoadAtomFeedTest_Local()
        {
        }

        [Test, Order(1)]
        public void LoadAtomFeedTest_Web()
        {
        }

        [Test, Order(2)]
        public void GetAtomFeedItemTest()
        {
        }
    }
}
