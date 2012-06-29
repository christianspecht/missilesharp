using System;
using NUnit.Framework;

namespace MissileSharp.Tests
{
    [TestFixture]
    public class CommandSetListTests
    {
        private CommandSetList list = null;

        [SetUp]
        public void Setup()
        {
            list = new CommandSetList();
        }

        [Test]
        public void Add_CommandSetNameIsEmpty_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => list.Add(string.Empty, "cmd", 1));
        }

        [Test]
        public void Add_CommandSetNameIsNull_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => list.Add(null, "cmd", 1));
        }

        [Test]
        public void Add_CommandIsNull_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => list.Add("name", null));
        }

        [Test]
        public void Add_CommandIsValid_ListContainsOneItem()
        {
            list.Add("name", "cmd", 1);
            Assert.AreEqual(1, list.GetCommandSet("name").Count);
        }
        
        [Test]
        public void Add_CommandIsValid_SavedCommandIsCorrect()
        {
            list.Add("name", "cmd", 1);
            Assert.AreEqual("cmd", list.GetCommandSet("name")[0].Command);
        }
        
        [Test]
        public void Add_CommandIsValid_SavedValueIsCorrect()
        {
            list.Add("name", "cmd", 1);
            Assert.AreEqual(1, list.GetCommandSet("name")[0].Value);
        }
        
        [Test]
        public void Add_TwoValidCommands_ListContainsTwoItems()
        {
            list.Add("name", "cmd1", 1);
            list.Add("name", "cmd2", 1);

            Assert.AreEqual(2, list.GetCommandSet("name").Count);
        }
        
        [Test]
        public void CountSets_EmptyList_ReturnsZero()
        {
            Assert.AreEqual(0, list.CountSets());
        }

        [Test]
        public void CountSets_ListWithOneItem_ReturnsOne()
        {
            list.Add("name", "cmd", 1);
            Assert.AreEqual(1, list.CountSets());
        }

        [Test]
        public void CountCommands_NonExistingCommandSet_ReturnsZero()
        {
            Assert.AreEqual(0, list.CountCommands("invalid"));
        }

        [Test]
        public void CountCommands_ExistingCommandSet_ReturnsCorrectNumberOfItems()
        {
            list.Add("name","cmd",1);
            Assert.AreEqual(1, list.CountCommands("name"));
        }

        [Test]
        public void GetCommandSet_NonExistingCommandSet_ReturnsEmptyList()
        {
            Assert.AreEqual(0, list.GetCommandSet("invalid").Count);
        }

        [Test]
        public void GetCommandSet_ExistingCommandSet_ReturnsListWithCorrectNumberOfItems()
        {
            list.Add("name", "cmd", 1);
            Assert.AreEqual(1, list.GetCommandSet("name").Count);
        }

        [Test]
        public void GetCommandSet_ExistingCommandSet_ReturnsValidCommand()
        {
            list.Add("name", "cmd", 1);
            Assert.AreEqual("cmd", list.GetCommandSet("name")[0].Command);
        }

        [Test]
        public void GetCommandSet_ExistingCommandSet_ReturnsValidValue()
        {
            list.Add("name", "cmd", 1);
            Assert.AreEqual(1, list.GetCommandSet("name")[0].Value);
        }
    }
}
