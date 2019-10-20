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
        public long CityId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string District { get; set; }
        public long Population { get; set; }
        public Country Country { get; set; }
    }
}
