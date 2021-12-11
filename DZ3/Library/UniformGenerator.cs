using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public class UniformGenerator : IRandomGenerator
    {
        Random generator;

        public UniformGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double Generate(double min, double max)
        {
            return generator.NextDouble() * (max - min) + min;
        }
    }
}
