using System;

namespace Forecast
{
    public class Weather
    {
        double temperature;
        double windSpeed;
        double humidity;

        public void SetTemperature(double temperature) { this.temperature = temperature; }
        public void SetWindSpeed(double windSpeed) { this.windSpeed = windSpeed; }
        public void SetHumidity(double humidity) { this.humidity = humidity; }

        public double GetTemperature() { return temperature; }
        public double GetWindSpeed() { return windSpeed; }
        public double GetHumidity() { return humidity; }

        public Weather(double temperature, double humidity, double windSpeed)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.windSpeed = windSpeed;
        }

        public Weather():  this (0, 0, 0) { }

        public string GetAsString()
        {
            return $"T={temperature}°C, w={windSpeed}km/h, h={humidity}%";
        }

        public double CalculateFeelsLikeTemperature()
        {
            double T = temperature;
            double R = humidity;
            double[] c = new double[] { -8.78469475556, 1.61139411, 2.33854883889, -0.14611605, -0.012308094, -0.0164248277778, 0.002211732, 0.00072546, -0.000003582 };
            return c[0] + c[1] * T + c[2] * R + c[3] * T * R + c[4] * T * T + c[5] * R * R + c[6] * T * T * R + c[7] * T * R * R + c[8] * T * T * R * R;
        }

        public double CalculateWindChill()
        {
            if (windSpeed < 4.8 || temperature >= 10) return 0;
            return 13.12 + 0.6215 * temperature - 11.37 * Math.Pow(windSpeed, 0.16) + 0.3965 * temperature * Math.Pow(windSpeed, 0.16);
        }
    }
}
