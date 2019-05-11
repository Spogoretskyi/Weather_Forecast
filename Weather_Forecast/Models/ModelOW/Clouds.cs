using Newtonsoft.Json;

namespace Weather_Forecast.Models.ModelOW
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}