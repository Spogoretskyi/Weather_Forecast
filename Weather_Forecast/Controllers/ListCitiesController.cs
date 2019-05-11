using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Weather_Forecast.Models.ModelOW;

namespace Weather_Forecast.Controllers
{
    public class ListCitiesController : ApiController
    {
        /// <summary>
        /// Post List of places by name
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ListCities/{city}")]
        public async Task<HttpResponseMessage> Post(string city)
        {
            var wi = await Task.Run(() => CityInfoWrapper.GetCity(city));
            if (wi.Count == 1 && wi.FirstOrDefault().Name == "NA")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, JsonConvert.SerializeObject(wi));
            if (wi.Count == 1 && wi.FirstOrDefault().Name == "NotExists")
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(wi));
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(wi));
        }
    }
}
