using Newtonsoft.Json;
using System.Collections.Generic;

namespace Weather_Forecast.Models.ModelOW
{
    public class RootObject
    {
        [JsonProperty("cod")]
        public string Cod { get; set; }
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("cnt")]
        public int Cnt { get; set; }
        [JsonProperty("list")]
        public List<List> List { get; set; }
        [JsonProperty("city")]
        public CityOW City { get; set; }
    }
}