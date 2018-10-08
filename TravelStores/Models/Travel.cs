using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TravelStores.Models
{
    public class Travel
    {
        public int TravelId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Hotel { get; set; }
        public int Price { get; set; }

        
        

        public Travel() { }
    }

   
}