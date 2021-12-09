using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class WeatherGenerator
    {
        double minTemperature, maxTemperature, minHumidity, maxHumidity, minWindSpeed, maxWindSpeed;
        IRandomGenerator randomGenerator;

        public WeatherGenerator(double minTemperature, double maxTemperature, double minHumidity, double maxHumidity, double minWindSpeed, double maxWindSpeed, IRandomGenerator randomGenerator)
        {
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            this.minHumidity = minHumidity;
            this.maxHumidity = maxHumidity;
            this.minWindSpeed = minWindSpeed;
            this.maxWindSpeed = maxWindSpeed;
            this.randomGenerator = randomGenerator;
        }

        public Weather Generate()
        {
            double temperature = randomGenerator.Generate(minTemperature, maxTemperature);
            double humidity = randomGenerator.Generate(minHumidity, maxHumidity);
            double windSpeed = randomGenerator.Generate(minWindSpeed, maxWindSpeed);
            return new Weather(temperature, humidity, windSpeed);
        }

        public void SetGenerator(IRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }
    }
}
