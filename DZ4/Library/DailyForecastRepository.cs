using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Forecast
{
    public class DailyForecastRepository : IEnumerable<DailyForecast>
    {
        List<DailyForecast> forecasts;

        public DailyForecastRepository() { forecasts = new List<DailyForecast>(); }
        public DailyForecastRepository(DailyForecastRepository repository)
        {
            forecasts = new List<DailyForecast>();
            forecasts.AddRange(repository.forecasts); 
        }

        public void Add(DailyForecast addForecast) 
        {
            int index = forecasts.FindIndex(forecast => forecast.Time.Date == addForecast.Time.Date);
            if (index==-1)
                forecasts.Add(addForecast);
            else
                forecasts[index] = addForecast;
        }
        public void Add(List<DailyForecast> addForecasts) 
        { 
            foreach(DailyForecast addForecast in addForecasts)
            {
                int index = forecasts.FindIndex(forecast => forecast.Time.Date == addForecast.Time.Date);
                if (index == -1)
                    forecasts.Add(addForecast);
                else
                    forecasts[index] = addForecast;
            }
        }

        public void Remove(DateTime date) 
        {
            int index = forecasts.FindIndex(forecast => forecast.Time.Date == date.Date);
            if (index == -1)
                throw new NoSuchDailyWeatherException(date, $"No daily forecast for {date.ToString()}");
            else
                forecasts.RemoveAt(index);
        }

        public IEnumerator<DailyForecast> GetEnumerator()
        {
            return ((IEnumerable<DailyForecast>)forecasts).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)forecasts).GetEnumerator();
        }

        public override string ToString()
        {
            List<DailyForecast> orederedForecasts = new List<DailyForecast>();
            orederedForecasts.AddRange(forecasts.OrderBy(forecast => forecast.Time));
            string output=orederedForecasts[0].ToString();
            for(int i=1;i<orederedForecasts.Count;i++)
            {
                output += $"{Environment.NewLine}{orederedForecasts[i].ToString()}";
            }
            return output;
        }
    }
}
