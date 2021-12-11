using System;
using System.Collections.Generic;
using System.Text;
using Printer;

namespace Forecast
{
    public class ForecastUtilities
    {
        public static DailyForecast Parse(string input)
        {
            string[] inputs = input.Split(',');
            Weather weather = new Weather();
            DailyForecast dailyForecast = new DailyForecast();
            dailyForecast.SetDay = DateTime.Parse(inputs[0]);
            weather.SetTemperature(double.Parse(inputs[1], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo));
            weather.SetHumidity(double.Parse(inputs[3], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo)); 
            weather.SetWindSpeed(double.Parse(inputs[2], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo));
            dailyForecast.SetDailyWeather = weather;
            return dailyForecast;
        }

        public static Weather FindWeatherWithLargestWindchill(Weather[] weathers)
        {
            Weather windWeather = new Weather();
            windWeather = weathers[0];
            double start = weathers[0].CalculateWindChill();
            double eachNum;
            for (int i = 1; i < weathers.Length; i++)
            {
                eachNum = weathers[i].CalculateWindChill();
                if (start < eachNum)
                {
                    windWeather = weathers[i];
                }
            }
            return windWeather;
        }

        public static void PrintWeathers(IPrinter[] printers, Weather[] weathers)
        {
            foreach (IPrinter printer in printers)
                    printer.Output(weathers);
        }
    }
}
