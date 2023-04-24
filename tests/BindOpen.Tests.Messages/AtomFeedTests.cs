﻿using BindOpen.Messages.Feeds.Atom;
using NUnit.Framework;

namespace BindOpen.Tests.Messages
{
    [TestFixture, Order(401)]
    public class AtomFeedTests
    {
        private readonly string _filePath = GlobalVariables.WorkingFolder + "Log.xml";

        private string feedUri = GlobalVariables.StorageUri + "news/atom/releases.atom";

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