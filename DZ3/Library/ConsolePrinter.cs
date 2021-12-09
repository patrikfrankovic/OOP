using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class ConsolePrinter : IPrinter
    {
        ConsoleColor color;

        public ConsolePrinter(ConsoleColor color)
        {
            this.color = color;
        }

        public void Output(Weather[] weathers)
        {
            Console.ForegroundColor = color;
            foreach (Weather weather in weathers)
            {
                Console.WriteLine(weather.ToString(),Console.ForegroundColor);
            }
            Console.WriteLine("\n");
        }
    }
}
