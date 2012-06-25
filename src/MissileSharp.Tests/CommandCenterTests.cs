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
        public void Up__SendsTwoCommands()
        {
            cmd.Up(0);
            Assert.AreEqual(2, device.ReceivedCommands.Count);
        }

        [Test]
        public void Up_FirstCommandIsUp()
        {
            cmd.Up(0);
            Assert.AreEqual(launcher.Up, device.ReceivedCommands[0]);
        }

        [Test]
        public void Up_SecondCommandIsStop()
        {
            cmd.Up(0);
            Assert.AreEqual(launcher.Stop, device.ReceivedCommands[1]);
        }
    }
}
