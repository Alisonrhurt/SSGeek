using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Models
{
    public class AlienTransportViewModel
    {
        public string Planet { get; set; }
        public string ModeOfTransport { get; set; }
        public double DestinationAge { get; set; }
        public double TravelTime { get; set; }
    }
}