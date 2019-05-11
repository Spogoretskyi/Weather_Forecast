using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Weather_Forecast.Models.ModelOW;

namespace Weather_Forecast.Controllers
{
    public class CurrentWeatherController : ApiController
    {
        private WeatherInfo weatherInfo = new WeatherInfo();

        /// <summary>
        /// Get Current weather by deafault (Kiev)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/CurrentWeather/")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<HttpResponseMessage> Get()
        {
            var wi = await Task.Run(() => weatherInfo.GetWeather());
            if (wi == "Internal Server Error")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, wi);
            return Request.CreateResponse(HttpStatusCode.OK, wi);
        }
        /// <summary>
        /// Post Current weather by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/CurrentWeather/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<HttpResponseMessage> Post(int id)
        {
            var wi = await Task.Run(() => weatherInfo.GetWeather("current", id));
            if (wi == "Internal Server Error")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, wi);
            return Request.CreateResponse(HttpStatusCode.OK, wi);
        }
    }
}