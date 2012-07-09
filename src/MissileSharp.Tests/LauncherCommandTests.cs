using System;
using NUnit.Framework;

namespace MissileSharp.Tests
{
    [TestFixture]
    public class LauncherCommandTests
    {
        [Test]
        public void CommandIsEmpty_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(()=> new LauncherCommand(string.Empty, 0));
        }

        [Test]
        public void CommandIsNull_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new LauncherCommand(null, 0));
        }

        [Test]
        public void ValueIsSmallerThanZero_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new LauncherCommand(Command.Up, -1));
        }

        [Test]
        public void ValidCommandAsEnum_IsSavedWithValue()
        {
            var cmd = new LauncherCommand(Command.Up, 100);
            Assert.AreEqual(Command.Up, cmd.Command);
            Assert.AreEqual(100, cmd.Value);
        }

        [Test]
        public void CommandAsString_IsConvertedToEnum()
        {
            var cmd = new LauncherCommand("up", 100);
            Assert.AreEqual(Command.Up, cmd.Command);
        }

        [Test]
        public void CommandAsUppercaseString_IsConvertedToEnum()
        {
            var cmd = new LauncherCommand("UP", 100);
            Assert.AreEqual(Command.Up, cmd.Command);
        }

        [Test]
        public void InvalidCommandAsString_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new LauncherCommand("invalid", 100));
        }
    }
}
