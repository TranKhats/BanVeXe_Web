using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class Flight
    {
        public Flight()
        {
            BookedSeat = new HashSet<BookedSeat>();
            DeatailClass = new HashSet<DeatailClass>();
        }

        public string IdFlight { get; set; }
        public int IdRoute { get; set; }
        public TimeSpan FlightDetail { get; set; }
        public DateTime Starting { get; set; }
        public DateTime Ending { get; set; }
        public string IdPlane { get; set; }
        public string IdDriver { get; set; }

        public Driver IdDriverNavigation { get; set; }
        public Plane IdPlaneNavigation { get; set; }
        public Route IdRouteNavigation { get; set; }
        public ICollection<BookedSeat> BookedSeat { get; set; }
        public ICollection<DeatailClass> DeatailClass { get; set; }
    }
}
