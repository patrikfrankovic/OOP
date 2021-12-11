using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public class BiasedGenerator : IRandomGenerator
    {
        Random generator;

        public BiasedGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double Generate(double min, double max)
        {
            return Math.Pow(generator.NextDouble(),2) * (max - min) + min;
        }
    }
}
