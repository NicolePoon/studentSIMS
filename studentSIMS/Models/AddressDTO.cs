using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentSIMS.Models
{
    public class AddressDTO
    {
        public int StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public int Postcode { get; set; }
        public string Country { get; set; }
    }
}
