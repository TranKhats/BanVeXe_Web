//using System;
//using System.Collections.Generic;

//namespace BanVeXe_Web.Models
//{
//    public partial class Shedule
//    {
//        public Shedule()
//        {
//            Ticket = new HashSet<Ticket>();
//            VariableSeat = new HashSet<VariableSeat>();
//        }

//        public string IdShedule { get; set; }
//        public string IdPlane { get; set; }
//        public string IdDriver { get; set; }
//        public string IdFlight { get; set; }

//        public Driver IdDriverNavigation { get; set; }
//        public Flight IdFlightNavigation { get; set; }
//        public Plane IdPlaneNavigation { get; set; }
//        public ICollection<Ticket> Ticket { get; set; }
//        public ICollection<VariableSeat> VariableSeat { get; set; }
//    }
//}
