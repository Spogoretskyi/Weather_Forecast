using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net;

namespace Weather_Forecast.Models.ModelOW
{
    public class WeatherInfo
    {
        private NameValueCollection appSettings = ConfigurationManager.AppSettings;
        public string GetWeather(string type = "current" ,int id = 703448)
        {
            var url = type == "current" ? appSettings["apiUrlCurrentWeatherOW"] : appSettings["apiUrlWeatherForecastOW"];
            string strCurrent = $"{url}{id}&{appSettings["apiUrlAppId"]}{appSettings["appidOW"]}";

            try
            {
                HttpWebRequest requestCurrent = WebRequest.Create(strCurrent) as HttpWebRequest;
                HttpWebResponse responseCurrent = (HttpWebResponse)requestCurrent.GetResponse();

                if (responseCurrent.StatusCode == HttpStatusCode.OK)
                {
                    string answerCurrent;
                    using (HttpWebResponse response = requestCurrent.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        answerCurrent = reader.ReadToEnd();
                    }
                    return answerCurrent;
                }
            }
            catch (Exception ex)
            {

            }
            return "Internal Server Error";
        }
    }
}