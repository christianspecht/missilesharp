using System;
using NUnit.Framework;

namespace MissileSharp.Tests.Library
{
    [TestFixture]
    public class CommandCenterTests
    {
        private CommandCenter cmd = null;
        private MockHidDevice device = null;
        private StubMissileLauncher launcher = null;

        [SetUp]
        public void Setup()
        {
            device = new MockHidDevice();
            launcher = new StubMissileLauncher();
            cmd = new CommandCenter(launcher, device);
        }

        [TearDown]
        public void Teardown()
        {
            cmd.Dispose();
        }

        [Test]
        public void SendCommand_Fire_SendsFire()
        {
            cmd.SendCommand(launcher.Fire);
            Assert.AreEqual(launcher.Fire, device.ReceivedCommands[0]);
        }

        [Test]
        public void SendMoveCommand_Up__SendsTwoCommands()
        {
            cmd.SendMoveCommand(launcher.Up, 0);
            Assert.AreEqual(2, device.ReceivedCommands.Count);
        }

        [Test]
        public void SendMoveCommand_Up_FirstCommandIsUp()
        {
            cmd.SendMoveCommand(launcher.Up, 0);
            Assert.AreEqual(launcher.Up, device.ReceivedCommands[0]);
        }

        [Test]
        public void SendMoveCommand_Up_SecondCommandIsStop()
        {
            cmd.SendMoveCommand(launcher.Up, 0);
            Assert.AreEqual(launcher.Stop, device.ReceivedCommands[1]);
        }

        [Test]
        public void Fire_ValidNumberOfShots_AreSentToLauncher()
        {
            cmd.Fire(launcher.MaxNumberOfShots);
            Assert.AreEqual(launcher.MaxNumberOfShots, device.ReceivedCommands.Count);
        }

        [Test]
        public void Fire_TooSmallNumberOfShots_IsSetToMinValue()
        {
            cmd.Fire(launcher.MinNumberOfShots - 1);
            Assert.AreEqual(launcher.MinNumberOfShots, device.ReceivedCommands.Count);
        }

        [Test]
        public void Fire_TooLargeNumberOfShots_IsSetToMaxValue()
        {
            cmd.Fire(launcher.MaxNumberOfShots + 1);
            Assert.AreEqual(launcher.MaxNumberOfShots, device.ReceivedCommands.Count);
        }

        [Test]
        public void RunCommand_Up_SendsUpCommand()
        {
            cmd.RunCommand(new LauncherCommand(Command.Up, 0));
            Assert.AreEqual(launcher.Up, device.ReceivedCommands[0]);
        }

        [Test]
        public void RunCommand_Down_SendsDownCommand()
        {
            cmd.RunCommand(new LauncherCommand(Command.Down, 0));
            Assert.AreEqual(launcher.Down, device.ReceivedCommands[0]);
        }

        [Test]
        public void RunCommand_Left_SendsLeftCommand()
        {
            cmd.RunCommand(new LauncherCommand(Command.Left, 0));
            Assert.AreEqual(launcher.Left, device.ReceivedCommands[0]);
        }

        [Test]
        public void RunCommand_Right_SendsRightCommand()
        {
            cmd.RunCommand(new LauncherCommand(Command.Right, 0));
            Assert.AreEqual(launcher.Right, device.ReceivedCommands[0]);
        }

        [Test]
        public void RunCommand_Fire_SendsFireCommand()
        {
            cmd.RunCommand(new LauncherCommand(Command.Fire, 0));
            Assert.AreEqual(launcher.Fire, device.ReceivedCommands[0]);
        }

        [Test]
        public void RunCommandSetString_NoSetsLoaded_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => cmd.RunCommandSet("invalid"));
        }

        [Test]
        public void LoadCommandSet_EmptyFile_ReturnsFalse()
        {
            var config = new string[] { };
            Assert.IsFalse(cmd.LoadCommandSets(config));
        }
    }
}
