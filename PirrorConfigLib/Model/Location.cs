using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirrorConfigLib.Model
{
    public class Location
    {
        public Location(string country, string city)
        {
            Country = country;
            City = city;
        }

        public string Country { get; }
        public string City { get; }
    }
}
