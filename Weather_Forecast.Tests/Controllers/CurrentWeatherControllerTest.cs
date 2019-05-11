using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;
using Weather_Forecast.Controllers;
using Weather_Forecast.Models.ModelOW;
using Assert = NUnit.Framework.Assert;

namespace Weather_Forecast.Tests.Controllers
{
    [TestFixture]
    public class CurrentWeatherControllerTest : ApiController
    {
        NormalizeJSON normalizeJson = new NormalizeJSON();

        [Test]
        public async Task GetCorrectWeatherObj()
        {
            // Arrange
            CurrentWeatherController controller = new CurrentWeatherController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = await controller.Get();
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<CurrentWeather>(normalizeJson.NormalizeObj(content),
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

            // Asserts
            Assert.IsInstanceOf<string>(result.Name);
            Assert.AreEqual("Kiev", result.Name);
            Assert.IsInstanceOf<int>(result.Id);
            Assert.AreEqual(703448, result.Id);
            Assert.IsInstanceOf<string>(result.Base);
            Assert.IsInstanceOf<Clouds>(result.Clouds);
            Assert.IsInstanceOf<int>(result.Clouds.All);
            Assert.IsInstanceOf<int>(result.Cod);
            Assert.IsInstanceOf<Coord>(result.Coord);
            Assert.IsInstanceOf<double>(result.Coord.Lat);
            Assert.AreEqual(Math.Round(50.433334), Math.Round(result.Coord.Lat));
            Assert.IsInstanceOf<double>(result.Coord.Lon);
            Assert.AreEqual(Math.Round(30.516666), Math.Round(result.Coord.Lon));
            Assert.IsInstanceOf<int>(result.Dt);
            Assert.IsInstanceOf<int>(result.Id);
            Assert.IsInstanceOf<Main>(result.Main);
            Assert.IsInstanceOf<double>(result.Main.GrndLevel);
            Assert.IsInstanceOf<int>(result.Main.Humidity);
            Assert.IsInstanceOf<double>(result.Main.Pressure);
            Assert.IsInstanceOf<double>(result.Main.SeaLevel);
            Assert.IsInstanceOf<double>(result.Main.Temp);
            Assert.IsInstanceOf<double>(result.Main.TempMax);
            Assert.IsInstanceOf<double>(result.Main.TempMin);
            Assert.IsInstanceOf<Sys>(result.Sys);
            Assert.IsInstanceOf<string>(result.Sys.Country);
            Assert.AreEqual("UA", result.Sys.Country);
            Assert.IsInstanceOf<double>(result.Sys.Message);
            Assert.IsInstanceOf<int>(result.Sys.Sunrise);
            Assert.IsInstanceOf<int>(result.Sys.Sunset);
            Assert.IsInstanceOf<Weather>(result.Weather.FirstOrDefault());
            Assert.IsInstanceOf<string>(result.Weather.FirstOrDefault().Description);
            Assert.IsInstanceOf<string>(result.Weather.FirstOrDefault().Icon);
            Assert.IsInstanceOf<int>(result.Weather.FirstOrDefault().Id);
            Assert.IsInstanceOf<string>(result.Weather.FirstOrDefault().Main);
            Assert.IsInstanceOf<Wind>(result.Wind);
            Assert.IsInstanceOf<string>(result.Wind.Deg);
            Assert.IsInstanceOf<double>(result.Wind.Speed);
        }

        [Test]
        public async Task GetWeatherObjIsNotNull()
        {
            // Arrange
            CurrentWeatherController controller = new CurrentWeatherController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = await controller.Get();
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<CurrentWeather>(normalizeJson.NormalizeObj(content),
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

            // Asserts
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task PostCorrectWeatherObj()
        {
            // Arrange
            CurrentWeatherController controller = new CurrentWeatherController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = await controller.Post(708546);
            var content = response.Content.ReadAsStringAsync().Result;

            var norm = normalizeJson.NormalizeObj(content);
            var result = JsonConvert.DeserializeObject<CurrentWeather>(norm);

            // Asserts
            Assert.IsInstanceOf<string>(result.Name);
            Assert.AreEqual("Holubynka", result.Name);
            Assert.IsInstanceOf<int>(result.Id);
            Assert.AreEqual(708546, result.Id);
            Assert.IsInstanceOf<string>(result.Base);
            Assert.IsInstanceOf<Clouds>(result.Clouds);
            Assert.IsInstanceOf<int>(result.Clouds.All);
            Assert.IsInstanceOf<int>(result.Cod);
            Assert.IsInstanceOf<Coord>(result.Coord);
            Assert.IsInstanceOf<double>(result.Coord.Lat);
            Assert.AreEqual(Math.Round(44.599998), Math.Round(result.Coord.Lat));
            Assert.IsInstanceOf<double>(result.Coord.Lon);
            Assert.AreEqual(Math.Round(33.900002), Math.Round(result.Coord.Lon));
            Assert.IsInstanceOf<int>(result.Dt);
            Assert.IsInstanceOf<int>(result.Id);
            Assert.IsInstanceOf<Main>(result.Main);
            Assert.IsInstanceOf<double>(result.Main.GrndLevel);
            Assert.IsInstanceOf<int>(result.Main.Humidity);
            Assert.IsInstanceOf<double>(result.Main.Pressure);
            Assert.IsInstanceOf<double>(result.Main.SeaLevel);
            Assert.IsInstanceOf<double>(result.Main.Temp);
            Assert.IsInstanceOf<double>(result.Main.TempMax);
            Assert.IsInstanceOf<double>(result.Main.TempMin);
            Assert.IsInstanceOf<Sys>(result.Sys);
            Assert.IsInstanceOf<string>(result.Sys.Country);
            Assert.AreEqual("UA", result.Sys.Country);
            Assert.IsInstanceOf<double>(result.Sys.Message);
            Assert.IsInstanceOf<int>(result.Sys.Sunrise);
            Assert.IsInstanceOf<int>(result.Sys.Sunset);
            Assert.IsInstanceOf<Weather>(result.Weather.FirstOrDefault());
            Assert.IsInstanceOf<string>(result.Weather.FirstOrDefault().Description);
            Assert.IsInstanceOf<string>(result.Weather.FirstOrDefault().Icon);
            Assert.IsInstanceOf<int>(result.Weather.FirstOrDefault().Id);
            Assert.IsInstanceOf<string>(result.Weather.FirstOrDefault().Main);
            Assert.IsInstanceOf<Wind>(result.Wind);
            Assert.IsInstanceOf<string>(result.Wind.Deg);
            Assert.IsInstanceOf<double>(result.Wind.Speed);
        }

        [Test]
        public async Task PostWeatherObjIsNotNull()
        {
            // Arrange
            CurrentWeatherController controller = new CurrentWeatherController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = await controller.Post(708546);
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<CurrentWeather>(normalizeJson.NormalizeObj(content),
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            // Asserts
            Assert.That(result, Is.Not.Null);
        }
    }
}
