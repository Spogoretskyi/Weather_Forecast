using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather_Forecast.Models.ModelOW
{
    public class List
    {
        [JsonProperty("dt")]
        public int Dt { get; set; }
        [JsonProperty("main")]
        public MainMulti Main { get; set; }
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("rain")]
        public Rain Rain { get; set; }
        [JsonProperty("sys")]
        public SysMulti Sys { get; set; }
        [JsonProperty("dt_txt")]
        public string DtTxt { get; set; }
    }
}