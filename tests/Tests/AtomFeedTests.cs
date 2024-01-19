using BindOpen.Messages.Feeds.Atom;
using NUnit.Framework;

namespace BindOpen.Messages.Tests
{
    [TestFixture, Order(401)]
    public class AtomFeedTests
    {
        private string feedUri = SystemData.StorageUri + "news/atom/releases.atom";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [Test, Order(1)]
        public void LoadAtomFeedTest_Local()
        {
            var feed = AtomFeedHandler.GetFeed(
                feedUri,
                titleMaxCharacterNumber: 25,
                descriptionMaxCharacterNumber: 25);
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
