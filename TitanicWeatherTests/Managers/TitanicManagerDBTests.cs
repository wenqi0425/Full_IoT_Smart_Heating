using Microsoft.VisualStudio.TestTools.UnitTesting;
using TitanicWeather.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanicWeather.Models;

namespace TitanicWeather.Managers.Tests
{
    /// <summary>
    /// testing for the functionality that should send the data for the charts on pi page
    /// </summary>
    [TestClass()]
    public class TitanicManagerDBTests
    {
        public static TitanicManagerDB manager = new TitanicManagerDB();
        public static List<Measurement> testDataFull = new List<Measurement>()
        {
            new Measurement(){Id=0,DateAndTime= DateTime.Now.Date.AddDays(-7), Temperature=(decimal)1.0, Humidity = 10, Pressure=1},
            new Measurement(){Id=1,DateAndTime= DateTime.Now.Date.AddDays(-6), Temperature=(decimal)1.5, Humidity = 20, Pressure=1},
            new Measurement(){Id=2,DateAndTime= DateTime.Now.Date.AddDays(-5), Temperature=(decimal)2.0, Humidity = 30, Pressure=1},
            new Measurement(){Id=3,DateAndTime= DateTime.Now.Date.AddDays(-4), Temperature=(decimal)3.5, Humidity = 40, Pressure=1},
            new Measurement(){Id=4,DateAndTime= DateTime.Now.Date.AddDays(-3), Temperature=(decimal)4.0, Humidity = 50, Pressure=1},
            new Measurement(){Id=5,DateAndTime= DateTime.Now.Date.AddDays(-2), Temperature=(decimal)3.2, Humidity = 55, Pressure=1},
            new Measurement(){Id=6,DateAndTime= DateTime.Now.Date.AddDays(-2), Temperature=(decimal)1.0, Humidity = 80, Pressure=1},
            new Measurement(){Id=7,DateAndTime= DateTime.Now.Date.AddDays(-2), Temperature=(decimal)1.2, Humidity = 54, Pressure=1},
            new Measurement(){Id=8,DateAndTime= DateTime.Now.Date.AddDays(-1), Temperature=(decimal)6.0, Humidity = 60, Pressure=1},
            new Measurement(){Id=9,DateAndTime= DateTime.Now.Date.AddDays(0), Temperature=(decimal)3.4, Humidity = 70, Pressure=1}
        };
        public static List<Measurement> testDataHoles = new List<Measurement>()
        {
            new Measurement(){Id=0,DateAndTime= DateTime.Now.Date.AddDays(-7), Temperature=(decimal)1.0, Humidity = 10, Pressure=1},
            new Measurement(){Id=1,DateAndTime= DateTime.Now.Date.AddDays(-7), Temperature=(decimal)1.5, Humidity = 20, Pressure=1},
            new Measurement(){Id=2,DateAndTime= DateTime.Now.Date.AddDays(-4), Temperature=(decimal)2.0, Humidity = 30, Pressure=1},
            new Measurement(){Id=3,DateAndTime= DateTime.Now.Date.AddDays(-4), Temperature=(decimal)3.5, Humidity = 40, Pressure=1},
            new Measurement(){Id=4,DateAndTime= DateTime.Now.Date.AddDays(-4), Temperature=(decimal)4.0, Humidity = 50, Pressure=1},
            new Measurement(){Id=5,DateAndTime= DateTime.Now.Date.AddDays(-2), Temperature=(decimal)3.2, Humidity = 55, Pressure=1},
            new Measurement(){Id=6,DateAndTime= DateTime.Now.Date.AddDays(-2), Temperature=(decimal)1.0, Humidity = 80, Pressure=1},
            new Measurement(){Id=7,DateAndTime= DateTime.Now.Date.AddDays(-2), Temperature=(decimal)1.2, Humidity = 54, Pressure=1},
            new Measurement(){Id=8,DateAndTime= DateTime.Now.Date.AddDays(-2), Temperature=(decimal)6.0, Humidity = 60, Pressure=1},
            new Measurement(){Id=9,DateAndTime= DateTime.Now.Date.AddDays(-2), Temperature=(decimal)3.4, Humidity = 70, Pressure=1}
        };


        [TestMethod()]
        public void SummarizeDataForTheDayTestNormal()
        {
            IEnumerable<Measurement> data = testDataHoles;
            DateTime currentDate = DateTime.Now.Date.AddDays(-2);
            IEnumerable<Measurement> ourData = data.Where(x => x.DateAndTime.Date == currentDate);
            SummarizedData res = manager.SummarizeDataForTheDay(data.Where(x => x.DateAndTime.Date == currentDate),currentDate);
            //assert
            Assert.AreEqual(DateTime.Now.Date.AddDays(-2), res.Date);
            Assert.AreEqual((decimal)6.0,res.MaxTemp);
            Assert.AreEqual((decimal)1.0,res.MinTemp);
            Assert.AreEqual(54,res.MinHumid);
            Assert.AreEqual(80,res.MaxHumid);
        }
        [TestMethod()]
        public void SummarizeDataForTheDayTestNull()
        {
            IEnumerable<Measurement> data = testDataHoles;
            DateTime currentDate = DateTime.Now.Date.AddDays(0);
            SummarizedData res = manager.SummarizeDataForTheDay(data.Where(x => x.DateAndTime.Date == currentDate), currentDate);
            //assert
            Assert.AreEqual(DateTime.Now.Date, res.Date);
            Assert.AreEqual(0, res.MaxTemp);
            Assert.AreEqual(0, res.MinTemp);
            Assert.AreEqual(0, res.MinHumid);
            Assert.AreEqual(0, res.MaxHumid);
        }

        [TestMethod()]
        public void GetSummarizedDataTest()
        {
            IEnumerable<Measurement> data = testDataFull;
            DateTime currentDate;
            List<SummarizedData> res = new List<SummarizedData>();
            for (int i = 6; i >= 0; i--)
            {
                currentDate = DateTime.Now.Date.AddDays(-i);
                res.Add(manager.SummarizeDataForTheDay(data.Where(x => x.DateAndTime.Date == currentDate),currentDate));
            }
            Assert.AreEqual(7,res.Count());

        }
        [TestMethod()]
        public void GetSummarizedDataTestFinal()
        {

            IEnumerable<SummarizedData> res = manager.GetSummarizedData();
            Assert.AreEqual(7, res.Count());

        }
    }
}