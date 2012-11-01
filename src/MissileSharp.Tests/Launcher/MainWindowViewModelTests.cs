﻿using System;
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
        private MockShutdownService shutdownservice;
        private ICommandCenterService commandcenterservice;
        private Mock<ICommandCenter> commandcenter;
        
        [SetUp]
        public void Setup()
        {
            this.commandcenterservice = new StubCommandCenterService();

            this.shutdownservice = new MockShutdownService();

            this.commandcenter = new Mock<ICommandCenter>();
            this.commandcenter.Setup(m => m.LoadCommandSets(It.IsAny<string[]>())).Returns(true);            
            this.commandcenter.Setup(m => m.GetLoadedCommandSetNames()).Returns(new List<string>());
        }

        public MainWindowViewModel SetupViewModel(ICommandCenterService commandCenterService = null, IConfigService configService = null, IMessageService messageService = null, IShutdownService shutdownService = null)
        {
            if (commandCenterService == null)
            {
                commandCenterService = this.commandcenterservice;
                ((StubCommandCenterService)this.commandcenterservice).CommandCenter = this.commandcenter.Object;
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
        public void Initialize_IsExecuted_DoesntShutdown()
        {
            // test that the viewmodel initializes correctly with all the mocked/stubbed stuff, without throwing an exception or shutting down
            var viewmodel = SetupViewModel();
            Assert.False(this.shutdownservice.ShutDownWasCalled);
        }

        [Test]
        public void Initialize_LoadCommandSetsThrows_AppShutsDown()
        {
            this.commandcenter.Setup(m => m.LoadCommandSets(It.IsAny<string[]>())).Throws<NotImplementedException>();
            var viewmodel = SetupViewModel();
            Assert.True(this.shutdownservice.ShutDownWasCalled);
        }

        [Test]
        public void FireCommand_IsExecuted_RunCommandSetIsCalled()
        {           
            var viewmodel = SetupViewModel();
            viewmodel.FireCommand.Execute("test");

            this.commandcenter.Verify(m => m.RunCommandSet("test"));
        }
    }
}
