using Newtonsoft.Json;

namespace Weather_Forecast.Models.ModelOW
{
    public class SysMulti
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}