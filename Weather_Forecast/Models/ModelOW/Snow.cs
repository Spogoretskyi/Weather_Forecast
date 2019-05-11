using Newtonsoft.Json;

namespace Weather_Forecast.Models.ModelOW
{
    public class Snow
    {
        [JsonProperty("snow")]
        public double SnowProp { get; set; }
    }
}
