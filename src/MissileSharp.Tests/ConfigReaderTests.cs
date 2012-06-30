using System.Collections.Generic;
using NUnit.Framework;

namespace MissileSharp.Tests
{
    [TestFixture]
    public class ConfigReaderTests
    {
        // get a valid config file (this is not in [SetUp] because there will be more tests with other config files)
        private CommandSetList GetValidConfig()
        {
            var conf = new List<string>();

            conf.Add("[name1]");
            conf.Add("up,10");
            conf.Add(string.Empty);
            conf.Add("[name2]");
            conf.Add("right,20");
            conf.Add("fire,2");

            return GetConfigFromList(conf);
        }

        // helper method to convert string[] config to CommandSetList
        private CommandSetList GetConfigFromList(List<string> config)
        {
            string[] configFile = config.ToArray();
            return ConfigReader.Read(configFile);
        }

        [Test]
        public void Read_ValidConfig_CreatesTwoCommandSets()
        {
            var config = GetValidConfig();
            Assert.AreEqual(2, config.CountSets());
        }

        [Test]
        public void Read_ValidConfig_NamesInConfigExistAsCommandSets()
        {
            var config = GetValidConfig();
            Assert.True(config.ContainsCommandSet("name1") && config.ContainsCommandSet("name2"));
        }

        [Test]
        public void Read_ValidConfig_NameNotInConfigDoesNotExistAsCommandSet()
        {
            var config = GetValidConfig();
            Assert.False(config.ContainsCommandSet("invalid"));
        }

        [Test]
        public void Read_ValidConfig_Name1HasOneCommand()
        {
            var config = GetValidConfig();
            Assert.AreEqual(1, config.CountCommands("name1"));
        }

        [Test]
        public void Read_ValidConfig_Name2HasTwoCommands()
        {
            var config = GetValidConfig();
            Assert.AreEqual(2, config.CountCommands("name2"));
        }

        [Test]
        public void Read_ValidConfig_Name1TheCommandIsCorrect()
        {
            var config = GetValidConfig();
            Assert.AreEqual("up", config.GetCommandSet("name1")[0].Command);
        }

        [Test]
        public void Read_ValidConfig_Name1TheValueIsCorrect()
        {
            var config = GetValidConfig();
            Assert.AreEqual(10, config.GetCommandSet("name1")[0].Value);
        }

        [Test]
        public void Read_ValidConfig_Name2TheFirstCommandIsCorrect()
        {
            var config = GetValidConfig();
            Assert.AreEqual("right", config.GetCommandSet("name2")[0].Command);
        }

        [Test]
        public void Read_ValidConfig_Name2TheFirstValueIsCorrect()
        {
            var config = GetValidConfig();
            Assert.AreEqual(20, config.GetCommandSet("name2")[0].Value);
        }

        [Test]
        public void Read_ValidConfig_Name2TheSecondCommandIsCorrect()
        {
            var config = GetValidConfig();
            Assert.AreEqual("fire", config.GetCommandSet("name2")[1].Command);
        }

        [Test]
        public void Read_ValidConfig_Name2TheSecondValueIsCorrect()
        {
            var config = GetValidConfig();
            Assert.AreEqual(2, config.GetCommandSet("name2")[1].Value);
        }
    }
}
