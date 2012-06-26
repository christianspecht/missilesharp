using NUnit.Framework;

namespace MissileSharp.Tests
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
    }
}
