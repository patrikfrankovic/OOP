using System;
using System.Collections.Generic;
using System.Text;

namespace Forecast
{
    public class WeeklyForecast
    {
        DailyForecast[] dailyForecasts;

        public WeeklyForecast(DailyForecast[] dailyForecasts)
        {
            this.dailyForecasts = dailyForecasts;
        }


        public string GetAsString()
        {
            string forcasts = dailyForecasts[0].GetAsString();
            for (int i=1;i<dailyForecasts.Length;i++)
            {
                forcasts += $"\n{dailyForecasts[i].GetAsString()}"; 
            }
            return forcasts;
        }

        public double GetMaxTemperature()
        {
            double max = dailyForecasts[0].GetDailyWeather.GetTemperature();
            for(int i=0;i<dailyForecasts.Length;i++)
                if(max < dailyForecasts[i].GetDailyWeather.GetTemperature())
                    max = dailyForecasts[i].GetDailyWeather.GetTemperature();
            return max;
        }

        public DailyForecast this[int i]
        {
            get => dailyForecasts[i];
        }
    }
}
