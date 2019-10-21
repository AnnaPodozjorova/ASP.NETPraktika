using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Models
{
    public class City
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string countrycode { get; set; }
        public string district { get; set; }
        public long population { get; set; }
        public Country Country { get; set; }
    }
}
