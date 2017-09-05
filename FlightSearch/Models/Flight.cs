using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightSearch.Models
{
    public class Flight
    {
        //From,To,FlightNumber,Departs,Arrives,MainCabinPrice,FirstClassPrice
        public string From { get; set; }

        public string To { get; set; }
        public int FlightNumber { get; set; }
        public DateTime Departs { get; set; }
        public DateTime Arrives { get; set; }
        public float MainCabinPrice { get; set; }
        public float FirstClassPrice { get; set; }
    }
}