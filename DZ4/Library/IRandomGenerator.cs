using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public interface IRandomGenerator
    {
        double Generate(double min, double max);
    }
}
