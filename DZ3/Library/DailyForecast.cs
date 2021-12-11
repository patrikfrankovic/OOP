using System;
using System.Collections.Generic;
using System.Text;

namespace Forecast
{
    public class DailyForecast
    {
        DateTime day;
        Weather dailyweather;

        public Weather GetDailyWeather { get { return dailyweather; } }
        public DateTime GetDay { get { return day; } }

        public Weather SetDailyWeather { set { this.dailyweather=value; } }
        public DateTime SetDay { set { this.day=value; } }

        public DailyForecast() : this(new DateTime(0), null) { }
        public DailyForecast(DateTime day, Weather weather)
        {
            this.day = day;
            this.dailyweather = weather;
        }

        public override string ToString()
        {
            return $"{day.ToString()}: {dailyweather.ToString()}";
        }
    }
}
