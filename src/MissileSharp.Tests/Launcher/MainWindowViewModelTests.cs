using System;
using MissileSharp.Launcher.ViewModels;
using NUnit.Framework;

namespace MissileSharp.Tests.Launcher
{
    [TestFixture]
    public class MainWindowViewModelTests
    {
        private MainWindowViewModel viewmodel;
        
        [SetUp]
        public void Setup()
        {
            var config = new StubConfigService();
            config.SetConfig(new string[] { "[name2]", "up,5", "[name1]", "up,5" });

            viewmodel = new MainWindowViewModel(config);
        }

        [Test]
        public void Constructor_ConfigWithTwoCommandSets_ObservableCollectionContainsTwoNames()
        {
            Assert.AreEqual(2, viewmodel.CommandSets.Count);
        }

        [Test]
        public void Constructor_ConfigWithTwoCommandSets_CollectionContainsOrderedCommandSets()
        {
            Assert.AreEqual("name1", viewmodel.CommandSets[0]);
            Assert.AreEqual("name2", viewmodel.CommandSets[1]);
        }

        [Test]
        public void Constructor_ConfigIsEmpty_ThrowsException()
        {
            var config = new StubConfigService();
            Assert.Throws<NullReferenceException>(() => new MainWindowViewModel(config));
        }
    }
}
