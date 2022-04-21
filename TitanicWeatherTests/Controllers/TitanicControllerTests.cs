using Microsoft.VisualStudio.TestTools.UnitTesting;
using TitanicWeather.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanicWeather.Models;

namespace TitanicWeather.Controllers.Tests
{
    [TestClass()]
    public class TitanicControllerTests
    {

        [TestMethod()]
        public void Test_If_GetRecent_Returns_Measurement_Type()
        {
            //Arrange
            TitanicController controller = new TitanicController();

            //Act
            Measurement result = controller.GetRecentMeasurement();

            //Assert
            Assert.IsInstanceOfType(result, typeof(Measurement));
        }

        [TestMethod()]
        public void Test_If_GetAll_Returns_IEnumMeasurement_Type()
        {
            //Arrange
            TitanicController controller = new TitanicController();

            //Act
            IEnumerable<Measurement> result = controller.GetAllMeasurements();

            //Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Measurement>));
        }
    }
}