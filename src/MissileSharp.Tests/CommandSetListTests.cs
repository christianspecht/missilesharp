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
            Assert.Throws<ArgumentNullException>(() => list.Add(string.Empty, Command.Up, 1));
        }

        [Test]
        public void Add_CommandSetNameIsNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => list.Add(null, Command.Up, 1));
        }

        [Test]
        public void Add_CommandIsNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => list.Add("name", null));
        }

        [Test]
        public void Add_CommandIsValid_ListContainsOneItem()
        {
            list.Add("name", Command.Up, 1);
            Assert.AreEqual(1, list.GetCommandSet("name").Count);
        }
        
        [Test]
        public void Add_CommandIsValid_SavedCommandIsCorrect()
        {
            list.Add("name", Command.Up, 1);
            Assert.AreEqual(Command.Up, list.GetCommandSet("name")[0].Command);
        }
        
        [Test]
        public void Add_CommandIsValid_SavedValueIsCorrect()
        {
            list.Add("name", Command.Up, 1);
            Assert.AreEqual(1, list.GetCommandSet("name")[0].Value);
        }
        
        [Test]
        public void Add_TwoValidCommands_ListContainsTwoItems()
        {
            list.Add("name", Command.Up, 1);
            list.Add("name", Command.Up, 1);
            Assert.AreEqual(2, list.GetCommandSet("name").Count);
        }

        [Test]
        public void Add_CommandSetWithUpperCase_IsSavedInLowerCase()
        {
            list.Add("NAME", Command.Up, 1);
            Assert.That(list.ContainsCommandSet("name"));
        }

        [Test]
        public void Add_SameCommandSetInUpperAndLowerCase_IsSavedInOneCommandSet()
        {
            list.Add("NAME", Command.Up, 1);
            list.Add("name", Command.Up, 1);
            Assert.AreEqual(2, list.CountCommands("name"));
        }

        [Test]
        public void CountSets_EmptyList_ReturnsZero()
        {
            Assert.AreEqual(0, list.CountSets());
        }

        [Test]
        public void CountSets_ListWithOneItem_ReturnsOne()
        {
            list.Add("name", Command.Up, 1);
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
            list.Add("name", Command.Up, 1);
            Assert.AreEqual(1, list.CountCommands("name"));
        }

        [Test]
        public void CountCommands_CommandSetWithUpperCase_ReturnsCorrectNumberOfItems()
        {
            list.Add("name", Command.Up, 1);
            Assert.AreEqual(1, list.CountCommands("NAME"));
        }

        [Test]
        public void GetCommandSet_NonExistingCommandSet_ReturnsEmptyList()
        {
            Assert.AreEqual(0, list.GetCommandSet("invalid").Count);
        }

        [Test]
        public void GetCommandSet_ExistingCommandSet_ReturnsListWithCorrectNumberOfItems()
        {
            list.Add("name", Command.Up, 1);
            Assert.AreEqual(1, list.GetCommandSet("name").Count);
        }

        [Test]
        public void GetCommandSet_ExistingCommandSet_ReturnsValidCommand()
        {
            list.Add("name", Command.Up, 1);
            Assert.AreEqual(Command.Up, list.GetCommandSet("name")[0].Command);
        }

        [Test]
        public void GetCommandSet_ExistingCommandSet_ReturnsValidValue()
        {
            list.Add("name", Command.Up, 1);
            Assert.AreEqual(1, list.GetCommandSet("name")[0].Value);
        }

        [Test]
        public void GetCommandSet_CommandSetWithUpperCase_IsFound()
        {
            list.Add("name", Command.Up, 1);
            Assert.AreEqual(1, list.GetCommandSet("NAME").Count);
        }

        [Test]
        public void ContainsCommandSet_ExistingCommandSet_ReturnsTrue()
        {
            list.Add("name", Command.Up, 1);
            Assert.True(list.ContainsCommandSet("name"));            
        }

        [Test]
        public void ContainsCommandSet_NonExistingCommandSet_ReturnsFalse()
        {
            Assert.False(list.ContainsCommandSet("invalid"));
        }

        [Test]
        public void ContainsCommandSet_CommandSetWithUpperCase_ReturnsTrue()
        {
            list.Add("name", Command.Up, 1);
            Assert.True(list.ContainsCommandSet("NAME"));
        }
    }
}
