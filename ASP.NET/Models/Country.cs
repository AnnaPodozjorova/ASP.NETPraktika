using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string code { get; set; }
        public string name { get; set; }
        public string continent { get; set; }
        public string region { get; set; }
        public long? surfacearea { get; set; }
        public string indepyear { get; set; }
        public long? population { get; set; }
        public double? lifeexpectancy { get; set; }
        public long? gnp { get; set; }
        public long? gnpold { get; set; }
        public string localname { get; set; }
        public string governmentform { get; set; }
        public string headofstate { get; set; }
        public long? capital { get; set; }
        public string code2 { get; set; }
        // public City City { get; set; }
        public ICollection<City> City { get; set; }

        public Country(string code, string name, string continent, string region, long? surfacearea, string indepyear, long? population, double lifeexpectancy, long? gnp, long? gnpold, string localname, string governmentform, string headofstate, long? capital, string code2)
        {
            this.code = code;
            this.name = name;
            this.continent = continent;
            this.region = region;
            this.surfacearea = surfacearea;
            this.indepyear = indepyear;
            this.population = population;
            this.lifeexpectancy = lifeexpectancy;
            this.gnp = gnp;
            this.gnpold = gnpold;
            this.localname = localname;
            this.governmentform = governmentform;
            this.headofstate = headofstate;
            this.capital = capital;
            this.code2 = code2;
        }

        public Country()
        {
        }
    }
}
