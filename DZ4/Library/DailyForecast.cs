using System;
using System.Collections.Generic;
using System.Text;

namespace Forecast
{
    public class DailyForecast
    {
        DateTime time;
        Weather weather;

        public Weather Weather 
        { 
            get { return weather; }
            set { this.weather = value; }
        }
        public DateTime Time 
        { 
            get { return time; }
            set { this.time = value; }
        }


        public DailyForecast() : this(new DateTime(0), null) { }
        public DailyForecast(DateTime time, Weather weather)
        {
            this.time = time;
            this.weather = weather;
        }

        public override string ToString()
        {
            return $"{time.ToString()}: {weather.ToString()}";
        }
    }
}
