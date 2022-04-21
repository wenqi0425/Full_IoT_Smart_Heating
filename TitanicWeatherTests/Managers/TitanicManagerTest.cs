using Microsoft.VisualStudio.TestTools.UnitTesting;
using TitanicWeather.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanicWeather.Models;
using TitanicWeather.Controllers;

namespace TitanicWeatherTests.Managers.Tests
{
    [TestClass()]
    public class TitanicManagerTest
    {      
        [TestMethod()]
        public void setComandAndThenGetSameCommand()
        {
            TitanicManager manager = new TitanicManager();
            var expected = 5;
            manager.SetCommand(expected);
            var actual = manager.GetCommand();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SetHeatingLevelAndThenGetSameHeatingLevel()
        {
            TitanicManager manager = new TitanicManager();
            var expected = 2;
            manager.SetHeatingLevel(expected);
            var actual = manager.GetHeatingLevel();

            Assert.AreEqual(expected, actual);
        }
    }
}
