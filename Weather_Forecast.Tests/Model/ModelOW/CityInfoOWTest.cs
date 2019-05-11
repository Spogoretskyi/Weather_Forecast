using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Weather_Forecast.Models.ModelOW;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using List = NUnit.Framework.List;

namespace Weather_Forecast.Tests.Model.ModelOW
{
    public class CityInfoOWTestBase
    {
        protected CityInfoOW cityInfoOWr;
        [SetUp]
        public void BeforeEach()
        {
            cityInfoOWr = new CityInfoOW();
        }
        [TearDown]
        public void AfterEach()
        {
            cityInfoOWr = null;
        }
    }

    [TestFixture]
    public class CityInfoOWTest : CityInfoOWTestBase
    {
        [Test]
        public void GetAllCityIsNotNull()
        {
            var allCities = cityInfoOWr.AllCities;
            Assert.IsNotNull(allCities);
        }
        [Test]
        public void GetAllCityType()
        {
            var allCities = cityInfoOWr.AllCities;
            Assert.IsInstanceOfType(allCities, typeof(List<CityOW>));
        }
        [Test]
        public void GetCityType()
        {
            var selectedCity = cityInfoOWr.GetCity("kiev");
            Assert.IsInstanceOfType(selectedCity, typeof(List<CityOW>));
        }
        [Test]
        public void GetCityIsNotNull()
        {
            var selectedCity = cityInfoOWr.GetCity("kiev");
            Assert.IsNotNull(selectedCity);
        }
        [Test]
        public void GetCityIfWrongName()
        {
            var selectedCity = cityInfoOWr.GetCity("yyyyyyyyyyyyyyyyyyyyyyyyyy");
            Assert.AreEqual(0, selectedCity.FirstOrDefault().Id);
            Assert.AreEqual("NotExists", selectedCity.FirstOrDefault().Country);
            Assert.AreEqual("NotExists", selectedCity.FirstOrDefault().Name);
            Assert.AreEqual(0, selectedCity.FirstOrDefault().Coord.Lat);
            Assert.AreEqual(0, selectedCity.FirstOrDefault().Coord.Lon);
        }
    }
}
