using System;
using System.Collections.Generic;
using System.Text;

namespace Forecast
{
    public class NoSuchDailyWeatherException : Exception
    {
        DateTime date;
        public NoSuchDailyWeatherException() { }
        public NoSuchDailyWeatherException(string message) : base(message) { }
        public NoSuchDailyWeatherException(string message, Exception innerException) : base(message,innerException) { }
        public NoSuchDailyWeatherException(DateTime date, string message) : base(message) 
        {
            this.date = date;
        }

    }
}
