using System;
using System.Collections.Generic;
using System.Text;
using Forecast;

namespace Printer
{
    public interface IPrinter
    {
        void Output(Weather[] weather);
    }
}
