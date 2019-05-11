using Newtonsoft.Json;

namespace Weather_Forecast.Models.ModelOW
{
    public class Rain
    {
        [JsonProperty("rain")]
        public double RainProp { get; set; }
    }
}