using System;
using System.Collections.Generic;
using System.Text;

namespace apiScraper
{
    class WeatherInfo
    {
        public string City { get; set; }
        public double Temperature { get; set; }
        public int Visibility { get; set; }

        public override string ToString() {
            return "City: " + this.City + ", Temperature: " + Temperature + ", Visibility: " + Visibility;
        }
    }
}
