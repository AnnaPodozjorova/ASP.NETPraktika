using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prakt2.Models
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Region{ get; set; }
        public long SurfaceArea { get; set; }
        public int IndepYear { get; set; }
        public long Population { get; set; }
        public double Lifeexpectancy { get; set; }
        public long gnp { get; set; }
        public long gnpold { get; set; }
        public string localname { get; set; }
        public string governmentform { get; set; }
        public string headofstate { get; set; }
        public long Capital { get; set; }
        public string code2 { get; set; }
    }
}
