using MissileSharp.Launcher.Services;
using Moq;
using NUnit.Framework;

namespace MissileSharp.Tests.Launcher
{
    [TestFixture]
    public class CommandCenterServiceTests
    {
        private ICommandCenterService commandcenterservice;
        private Mock<IAppConfigService> appconfigservice;

        [SetUp]
        public void Setup()
        {
            this.appconfigservice = new Mock<IAppConfigService>();
            this.appconfigservice.Setup(stub => stub.LauncherName).Returns("MissileSharp.Tests.StubMissileLauncher");
            this.appconfigservice.Setup(stub => stub.LauncherAssembly).Returns("MissileSharp.Tests.dll");
            this.commandcenterservice = new CommandCenterService(this.appconfigservice.Object);
        }

        [Test]
        public void GetCommandCenter_ValidLauncher_ReturnsCommandCenter()
        {
            var commandCenter = this.commandcenterservice.GetCommandCenter();
            Assert.True(commandCenter is CommandCenter);
        }
    }
}
