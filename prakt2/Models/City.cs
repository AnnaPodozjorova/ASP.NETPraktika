using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prakt2.Models
{
    public class City
    {
        public long CityId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string District { get; set; }
        public long Population { get; set; }
    }
}
