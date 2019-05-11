using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using NUnit.Framework;
using Weather_Forecast.Controllers;
using Weather_Forecast.Models.ModelOW;
using Assert = NUnit.Framework.Assert;

namespace Weather_Forecast.Tests.Controllers
{
    [TestFixture]
    public class ListCitiesControllerTest : ApiController
    {
        NormalizeJSON normalizeJson = new NormalizeJSON();
        private static List<CityOW> _emptyObj()
        {
            var emptyObj = new List<CityOW>
            {
                new CityOW()
                {
                    Id = 0,
                    Country = "NotExists",
                    Name = "NotExists",
                    Coord = new Coord() {Lon = 0, Lat = 0}
                }
            };
            return emptyObj;
        }

        private static List<CityOW> _kievObj = new List<CityOW>()
        {
            new CityOW()
            {
                Id = 703448,
                Name = "Kiev",
                Country = "UA",
                Coord = new Coord() {Lon = 30.516666, Lat = 50.433334}
            },
            new CityOW()
            {
                Id = 6697077,
                Name = "Kievskij",
                Country = "RU",
                Coord = new Coord() {Lon = 36.89827, Lat = 55.436417}
            },
            new CityOW()
            {
                Id = 1522605,
                Name = "Kievka",
                Country = "KZ",
                Coord = new Coord() {Lon = 71.551392, Lat = 50.26194}
            },
            new CityOW()
            {
                Id = 2890943,
                Name = "Kieve",
                Country = "DE",
                Coord = new Coord() {Lon = 12.59377, Lat = 53.274559}
            },
            new CityOW()
            {
                Id = 6548066,
                Name = "Kieve",
                Country = "DE",
                Coord = new Coord() {Lon = 12.6, Lat = 53.283298}
            }
        };

        [Test]
        public async Task PostReturnStatusCodeNotOk()
        {
            // Arrange
            ListCitiesController controller = new ListCitiesController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = await controller.Post("yyyyyyyyyyyy");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public async Task PostReturnStatusCodeOk()
        {
            // Arrange
            ListCitiesController controller = new ListCitiesController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = await controller.Post("kiev");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public async Task PostReturnCorrectObj()
        {
            // Arrange
            ListCitiesController controller = new ListCitiesController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = await controller.Post("kiev");
            var content = response.Content.ReadAsStringAsync().Result;
            
            var result = JsonConvert.DeserializeObject<List<CityOW>>(normalizeJson.NormalizeObj(content), 
                new JsonSerializerSettings{ NullValueHandling = NullValueHandling.Ignore}  );

            var except = _kievObj.Except(result);
            // Assert
            Assert.AreEqual(except, Enumerable.Empty<CityOW>());
        }
        [Test]
        public async Task PostReturnCorrectEmptyObj()
        {
            // Arrange
            ListCitiesController controller = new ListCitiesController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act
            var response = await controller.Post("yyyyyyyyyy");
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<List<CityOW>>(normalizeJson.NormalizeObj(content),
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            var except = _emptyObj().Except(result);
            // Assert
            Assert.AreEqual(except, Enumerable.Empty<CityOW>());
        }
    }
}
