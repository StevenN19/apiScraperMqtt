﻿using System;

namespace apiScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MqttPublisher publisher = new MqttPublisher();
            WeatherRetriever weather = new WeatherRetriever();
            Console.WriteLine(weather.fetchWeatherInfo("Rotterdam"));
        }
    }
}
