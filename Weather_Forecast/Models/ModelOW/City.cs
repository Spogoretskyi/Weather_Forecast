using Newtonsoft.Json;

namespace Weather_Forecast.Models.ModelOW
{
    public abstract class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("coord")]
        public Coord Coord { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
