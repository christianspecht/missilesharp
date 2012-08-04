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
            var config = new string[]
            {
                "[name1]",
                "up,5",
                "[name2]",
                "up,5"
            };

            viewmodel = new MainWindowViewModel(config);
        }

        [Test]
        public void Constructor_ConfigWithTwoCommandSets_ObservableCollectionContainsTwoNames()
        {
            Assert.AreEqual(2, viewmodel.CommandSets.Count);
        }
    }
}
