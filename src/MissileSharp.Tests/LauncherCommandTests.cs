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
            Assert.Throws<InvalidOperationException>(() => new LauncherCommand("cmd", -1));
        }

        [Test]
        public void ConstructorParametersAreSavedInProperties()
        {
            var cmd = new LauncherCommand("up", 100);
            Assert.AreEqual("up", cmd.Command);
            Assert.AreEqual(100, cmd.Value);
        }

        [Test]
        public void CommandIsAlwaysSavedInLowerCase()
        {
            var cmd = new LauncherCommand("UP",0);
            Assert.AreEqual("up", cmd.Command);
        } 
    }
}
