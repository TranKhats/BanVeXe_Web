using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class Route
    {
        public Route()
        {
            Flight = new HashSet<Flight>();
        }

        public int IdRoute { get; set; }
        public string IdDestination { get; set; }
        public string IdDepacture { get; set; }

        public Place IdDepactureNavigation { get; set; }
        public Place IdDestinationNavigation { get; set; }
        public ICollection<Flight> Flight { get; set; }
    }
}
