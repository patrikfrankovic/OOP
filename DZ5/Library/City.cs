using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class City
    {
        public double id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Coord coord { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}
