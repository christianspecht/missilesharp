using System;
using System.Collections.Generic;
using MissileSharp.Launcher.Services;
using MissileSharp.Launcher.ViewModels;
using Moq;
using NUnit.Framework;

namespace MissileSharp.Tests.Launcher
{
    [TestFixture]
    public class MainWindowViewModelTests
    {
        private Mock<IShutdownService> shutdownservice;
        private Mock<ICommandCenterService> commandcenterservice;
        private Mock<ICommandCenter> commandcenter;
        
        [SetUp]
        public void Setup()
        {
            this.commandcenterservice = new Mock<ICommandCenterService>();            

            this.shutdownservice = new Mock<IShutdownService>();

            this.commandcenter = new Mock<ICommandCenter>();
            this.commandcenter.Setup(mock => mock.LoadCommandSets(It.IsAny<string[]>())).Returns(true);
            this.commandcenter.Setup(mock => mock.GetLoadedCommandSetNames()).Returns(new List<string>());
        }

        public MainWindowViewModel SetupViewModel(ICommandCenterService commandCenterService = null, IConfigService configService = null, IMessageService messageService = null, IShutdownService shutdownService = null)
        {
            if (commandCenterService == null)
            {
                this.commandcenterservice.Setup(stub => stub.GetCommandCenter()).Returns(this.commandcenter.Object);
                commandCenterService = this.commandcenterservice.Object;
            }

            if (configService == null)
            {
                configService = new Mock<IConfigService>().Object;
            }

            if (messageService == null)
            {
                messageService = new Mock<IMessageService>().Object;
            }

            if (shutdownService == null)
            {
                shutdownService = this.shutdownservice.Object;
            }

            return new MainWindowViewModel(commandCenterService, configService, messageService, shutdownService);
        }

        [Test]
        public void Initialize_IsExecuted_DoesntShutdown()
        {
            // test that the viewmodel initializes correctly with all the mocked/stubbed stuff, without throwing an exception or shutting down
            var viewmodel = SetupViewModel();
            this.shutdownservice.Verify(mock => mock.Shutdown(), Times.Never());
        }

        [Test]
        public void Initialize_LoadCommandSetsThrows_AppShutsDown()
        {
            this.commandcenter.Setup(m => m.LoadCommandSets(It.IsAny<string[]>())).Throws<NotImplementedException>();
            var viewmodel = SetupViewModel();
            this.shutdownservice.Verify(mock => mock.Shutdown());
        }

        [Test]
        public void FireCommand_IsExecuted_RunCommandSetIsCalled()
        {           
            var viewmodel = SetupViewModel();
            viewmodel.FireCommand.Execute("test");

            this.commandcenter.Verify(mock => mock.RunCommandSet("test"));
        }
    }
}
