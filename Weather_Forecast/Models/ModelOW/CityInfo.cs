using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Forecast.Models.ModelOW
{
    public abstract class CityInfo<T> where T: City
    {
        protected abstract List<T> GetAllCities();
        public abstract List<T> GetCity(string city);
    }
}
