using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using NUnit.Framework;
using Weather_Forecast.Controllers;
using Weather_Forecast.Models.ModelOW;

namespace Weather_Forecast.Tests.Controllers
{
    [TestFixture]
    class WeatherForecastControllerTest : ApiController
    {
        NormalizeJSON normalizeJson = new NormalizeJSON();

        [Test]
        public async Task PostCorrectForecastObj()
        {
            // Arrange
            WeatherForecastController controller = new WeatherForecastController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = await controller.Post(708546);
            var content = response.Content.ReadAsStringAsync().Result;

            var norm = normalizeJson.NormalizeObj(content);
            var result = JsonConvert.DeserializeObject<RootObject>(norm);

            // Asserts
            Assert.IsInstanceOf<City>(result.City);
            Assert.IsInstanceOf<string>(result.City.Name);
            Assert.AreEqual("Holubynka", result.City.Name);
            Assert.IsInstanceOf<int>(result.City.Id);
            Assert.AreEqual(708546, result.City.Id);
            Assert.IsInstanceOf<string>(result.City.Country);
            Assert.AreEqual("UA", result.City.Country);
            Assert.IsInstanceOf<Coord>(result.City.Coord);
            Assert.IsInstanceOf<double>(result.City.Coord.Lat);
            Assert.IsInstanceOf<double>(result.City.Coord.Lon);
            Assert.IsInstanceOf<string>(result.Cod);
            Assert.IsInstanceOf<double>(result.Message);
            Assert.IsInstanceOf<Clouds>(result.List.FirstOrDefault().Clouds);
            Assert.IsInstanceOf<int>(result.List.FirstOrDefault().Clouds.All);
            Assert.IsInstanceOf<int>(result.List.FirstOrDefault().Dt);
            Assert.IsInstanceOf<string>(result.List.FirstOrDefault().DtTxt);
            Assert.IsInstanceOf<Main>(result.List.FirstOrDefault().Main);
            Assert.IsInstanceOf<double>(result.List.FirstOrDefault().Main.TempKf);
            Assert.IsInstanceOf<double>(result.List.FirstOrDefault().Main.GrndLevel);
            Assert.IsInstanceOf<int>(result.List.FirstOrDefault().Main.Humidity);
            Assert.IsInstanceOf<double>(result.List.FirstOrDefault().Main.Pressure);
            Assert.IsInstanceOf<double>(result.List.FirstOrDefault().Main.SeaLevel);
            Assert.IsInstanceOf<double>(result.List.FirstOrDefault().Main.SeaLevel);
            Assert.IsInstanceOf<double>(result.List.FirstOrDefault().Main.Temp);
            Assert.IsInstanceOf<double>(result.List.FirstOrDefault().Main.TempMax);
            Assert.IsInstanceOf<double>(result.List.FirstOrDefault().Main.TempMin);
            Assert.IsInstanceOf<SysMulti>(result.List.FirstOrDefault().Sys);
            Assert.IsInstanceOf<string>(result.List.FirstOrDefault().Sys.Pod);
            Assert.IsInstanceOf<Weather>(result.List.FirstOrDefault().Weather.FirstOrDefault());
            Assert.IsInstanceOf<string>(result.List.FirstOrDefault().Weather.FirstOrDefault().Description);
            Assert.IsInstanceOf<string>(result.List.FirstOrDefault().Weather.FirstOrDefault().Icon);
            Assert.IsInstanceOf<int>(result.List.FirstOrDefault().Weather.FirstOrDefault().Id);
            Assert.IsInstanceOf<string>(result.List.FirstOrDefault().Weather.FirstOrDefault().Main);
            Assert.IsInstanceOf<Wind>(result.List.FirstOrDefault().Wind);
            Assert.IsInstanceOf<string>(result.List.FirstOrDefault().Wind.Deg);
            Assert.IsInstanceOf<double>(result.List.FirstOrDefault().Wind.Speed);
        }

        [Test]
        public async Task PostForecastObjIsNotNull()
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
