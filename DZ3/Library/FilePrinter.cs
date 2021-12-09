using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Library
{
    public class FilePrinter : IPrinter
    {
        string filename;

        public FilePrinter(string filename)
        {
            this.filename = filename;
        }

        public void Output(Weather[] weathers)
        {
            using (StreamWriter file = new StreamWriter(filename, true))
            {
                foreach (Weather weather in weathers)
                {
                    file.WriteLine(weather.ToString());
                }
                file.WriteLine("\n");
            }

        }
    }
}
