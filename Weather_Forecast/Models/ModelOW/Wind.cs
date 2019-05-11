using Newtonsoft.Json;

namespace Weather_Forecast.Models.ModelOW
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public string Deg { get; set; }
    }
}