using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Weather_Forecast.Models.ModelOW;

namespace Weather_Forecast.Controllers
{
    public class WeatherForecastController : ApiController
    {
        private WeatherInfo weatherInfo = new WeatherInfo();
        /// <summary>
        /// Post weather forecast by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/WeatherForecast/{id}")]
        public async Task<HttpResponseMessage> Post(int id)
        {
            var wi = await Task.Run(() => weatherInfo.GetWeather("forecast", id));
            if (wi == "Internal Server Error")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, wi);
            return Request.CreateResponse(HttpStatusCode.OK, wi);
        }
    }
}
