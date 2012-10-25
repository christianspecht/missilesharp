using MissileSharp.Launcher.Services;
using MissileSharp.Launcher.ViewModels;
using NUnit.Framework;

namespace MissileSharp.Tests.Launcher
{
    [TestFixture]
    public class MainWindowViewModelTests
    {
        private MockShutdownService shutdownservice;
        private ICommandCenterService commandcenterservice;
        private MockCommandCenter commandcenter;
        
        [SetUp]
        public void Setup()
        {            
            this.commandcenter = new MockCommandCenter();
            this.commandcenterservice = new StubCommandCenterService();
            ((StubCommandCenterService)commandcenterservice).CommandCenter = this.commandcenter;

            this.shutdownservice = new MockShutdownService();
        }

        public MainWindowViewModel SetupViewModel(ICommandCenterService commandCenterService = null, IConfigService configService = null, IMessageService messageService = null, IShutdownService shutdownService = null)
        {
            if (commandCenterService == null)
            {
                commandCenterService = this.commandcenterservice;
            }

            if (configService == null)
            {
                configService = new StubConfigService();
            }

            if (messageService == null)
            {
                messageService = new StubMessageService();
            }

            if (shutdownService == null)
            {
                shutdownService = this.shutdownservice;
            }

            return new MainWindowViewModel(commandCenterService, configService, messageService, shutdownService);
        }

        [Test]
        public void FireCommand_IsExecuted_RunCommandSetIsCalled()
        {
            var viewmodel = SetupViewModel();
            viewmodel.FireCommand.Execute("test");

            Assert.True(this.commandcenter.RunCommandSetWithStringWasCalled);
            Assert.AreEqual("test", this.commandcenter.RunCommandSetCommandSetName);
        }
    }
}
