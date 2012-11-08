using System;
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

        public ICommandCenterService SetupCommandCenterService()
        {
            return new CommandCenterService(this.appconfigservice.Object);
        }

        [Test]
        public void GetCommandCenter_ValidLauncher_ReturnsCommandCenter()
        {
            var commandCenter = SetupCommandCenterService().GetCommandCenter();
            Assert.True(commandCenter is CommandCenter);
        }

        [Test]
        public void GetCommandCenter_InvalidLauncher_Throws()
        {
            this.appconfigservice.Setup(stub => stub.LauncherName).Returns("MissileSharp.Tests.InvalidLauncher");
            Assert.Catch<Exception>(() => SetupCommandCenterService().GetCommandCenter());
        }

        [Test]
        public void GetCommandCenter_EmptyLauncher_Throws()
        {
            this.appconfigservice.Setup(stub => stub.LauncherName).Returns((string)null);
            this.appconfigservice.Setup(stub => stub.LauncherAssembly).Returns((string)null);

            Assert.Catch<Exception>(() => SetupCommandCenterService().GetCommandCenter());
        }
    }
}
