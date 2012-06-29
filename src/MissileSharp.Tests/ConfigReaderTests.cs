using System.Collections.Generic;
using NUnit.Framework;

namespace MissileSharp.Tests
{
    [TestFixture]
    public class ConfigReaderTests
    {
        private Dictionary<string, List<LauncherCommand>> dict;

        [TearDown]
        public void TearDown()
        {
            dict = null;
        }

        // this is not in [SetUp] because there will be more tests with other config files
        public Dictionary<string, List<LauncherCommand>> GetValidConfig()
        {
            var conf = new List<string>();

            conf.Add("[name1]");
            conf.Add("up,10");
            conf.Add(string.Empty);
            conf.Add("[name2]");
            conf.Add("right,20");
            conf.Add("fire,2");

            string[] configFile = conf.ToArray();
            return ConfigReader.Read(configFile);
        }

        [Test]
        public void Read_ValidConfig_CreatesTwoDictionaryEntries()
        {
            dict = GetValidConfig();
            Assert.AreEqual(2, dict.Count);
        }

        [Test]
        public void Read_ValidConfig_NamesInConfigExistInDictionary()
        {
            dict = GetValidConfig();
            Assert.True(dict.ContainsKey("name1"));
            Assert.True(dict.ContainsKey("name2"));
        }

        [Test]
        public void Read_ValidConfig_NameNotInConfigDoesNotExistInDictionary()
        {
            dict = GetValidConfig();
            Assert.False(dict.ContainsKey("invalid"));
        }

        [Test]
        public void Read_ValidConfig_Name1HasOneCommand()
        {
            dict = GetValidConfig();
            Assert.AreEqual(1, dict["name1"].Count);
        }

        [Test]
        public void Read_ValidConfig_Name2HasTwoCommands()
        {
            dict = GetValidConfig();
            Assert.AreEqual(2, dict["name2"].Count);
        }

        [Test]
        public void Read_ValidConfig_Name1TheCommandIsCorrect()
        {
            dict = GetValidConfig();
            Assert.AreEqual("up", dict["name1"][0].Command);
        }

        [Test]
        public void Read_ValidConfig_Name1TheValueIsCorrect()
        {
            dict = GetValidConfig();
            Assert.AreEqual(10, dict["name1"][0].Value);
        }

        [Test]
        public void Read_ValidConfig_Name2TheFirstCommandIsCorrect()
        {
            dict = GetValidConfig();
            Assert.AreEqual("right", dict["name2"][0].Command);
        }

        [Test]
        public void Read_ValidConfig_Name2TheFirstValueIsCorrect()
        {
            dict = GetValidConfig();
            Assert.AreEqual(20, dict["name2"][0].Value);
        }

        [Test]
        public void Read_ValidConfig_Name2TheSecondCommandIsCorrect()
        {
            dict = GetValidConfig();
            Assert.AreEqual("fire", dict["name2"][1].Command);
        }

        [Test]
        public void Read_ValidConfig_Name2TheSecondValueIsCorrect()
        {
            dict = GetValidConfig();
            Assert.AreEqual(2, dict["name2"][1].Value);
        }
    }
}
