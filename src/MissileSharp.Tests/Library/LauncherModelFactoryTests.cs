using System;
using System.IO;
using NUnit.Framework;

namespace MissileSharp.Tests.Library
{
    [TestFixture]
    public class LauncherModelFactoryTests
    {
        [Test]
        public void GetLauncher_ValidLauncherName_ReturnsLauncherInstance()
        {
            var launcher = LauncherModelFactory.GetLauncher("MissileSharp.ThunderMissileLauncher");
            Assert.That(launcher is ThunderMissileLauncher);
        }

        [Test]
        public void GetLauncher_ValidLauncherNameInDifferentAssembly_ReturnsLauncherInstance()
        {
            var launcher = LauncherModelFactory.GetLauncher("MissileSharp.Tests.StubMissileLauncher", "MissileSharp.Tests.dll");
            Assert.That(launcher is StubMissileLauncher);
        }

        [Test]
        public void GetLauncher_InvalidLauncherName_ThrowsException()
        {
            Assert.Throws<TypeLoadException>(() => LauncherModelFactory.GetLauncher("MissileSharp.InvalidLauncher"));
        }

        [Test]
        public void GetLauncher_InvalidAssemblyName_Throws()
        {
            Assert.Throws<FileNotFoundException>(() => LauncherModelFactory.GetLauncher("MissileSharp.InvalidLauncher", "Invalid.dll"));
        }
    }
}
