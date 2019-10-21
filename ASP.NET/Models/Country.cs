using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Models
{
    public class Country
    {
        [Key]
        public string code { get; set; }
        public string name { get; set; }
        public string continent { get; set; }
        public string region { get; set; }
        public long surfacearea { get; set; }
        public int indepyear { get; set; }
        public long population { get; set; }
        public double lifeexpectancy { get; set; }
        public long gnp { get; set; }
        public long gnpold { get; set; }
        public string localname { get; set; }
        public string governmentform { get; set; }
        public string headofstate { get; set; }
        public long capital { get; set; }
        public string code2 { get; set; }
        public City City { get; set; }
    }
}
