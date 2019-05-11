using Newtonsoft.Json;

namespace Weather_Forecast.Models.ModelOW
{
    public class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }
        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}