using Newtonsoft.Json;

namespace Weather_Forecast.Models.ModelOW
{
    public class MainMulti : Main
    {
        [JsonProperty("temp_kf")]
        public double TempKf { get; set; }
    }
}