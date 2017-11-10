using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace apiScraper
{
    class WeatherRetriever
    {
        private double temperature { get; set; }

        public WeatherInfo fetchWeatherInfo(string city)
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=" + city + ",nl&units=metric&appid=a88f8f230cf5df406e00f18315eef6a7");
                
                JObject jsonObject = JObject.Parse(json);
                WeatherInfo info = new WeatherInfo();
                info.City = (string)jsonObject["name"];
                info.Temperature = (double)jsonObject["main"]["temp"];
                info.Visibility = (int)jsonObject["visibility"];
                //double temp = (double) jsonObject["main"]["temp"];
                //Console.WriteLine(jsonObject["main"]["temp"].ToString());
                return info;
            }
        }
    }
}
