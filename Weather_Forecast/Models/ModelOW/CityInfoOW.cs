using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using System.Linq;
using System.Web.Hosting;
using System.Web.UI.WebControls;

namespace Weather_Forecast.Models.ModelOW
{
    public class CityInfoOW : CityInfo<CityOW>
    {
        private static List<CityOW> EmptyObj()
        {
            var emptyObj = new List<CityOW>
            {
                new CityOW()
                {
                    Id = 0,
                    Country = "NA",
                    Name = "NA",
                    Coord = new Coord() {Lon = 0, Lat = 0}
                }
            };
            return emptyObj;
        }
        private static List<CityOW> NotExistsObj()
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
        public List<CityOW> AllCities
        {
            get { return GetAllCities();  }
        }

        protected override List<CityOW> GetAllCities()
        {
            var testPath = AppDomain.CurrentDomain.BaseDirectory;
            
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            var path = $@"{appSettings["filePathToDownloadOW"]}{appSettings["fileNameToDownloadOW"]}";
            var fullPath = HostingEnvironment.MapPath(path) == null ? Path.GetFullPath(Path.Combine(testPath, @"..\..\..\", "Weather_Forecast\\Models\\Files\\city.list.json"))
                : HostingEnvironment.MapPath(path);
            if (!File.Exists(fullPath)) return EmptyObj();
            string file = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<List<CityOW>>(file);
        }

        public override List<CityOW> GetCity(string city)
        {
            if (GetAllCities().FirstOrDefault().Name == "NA")
                return GetAllCities();
            if (GetAllCities().Exists(c => c.Name.ToLower().Contains(city.ToLower())))
                return GetAllCities().FindAll(c => c.Name.ToLower().Contains(city.ToLower()));
            return NotExistsObj();
        }
    }
}