using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather_Forecast.Models.ModelOW
{
    public static class CityInfoWrapper
    {
        public static List<CityOW> GetCity(string city)
        {
            var cities = new CityInfoOW();
            return cities.GetCity(city);
        }
        public static int CityId { get; set; }
    }
}