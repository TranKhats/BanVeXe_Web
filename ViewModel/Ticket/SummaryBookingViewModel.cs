using BanVeXe_Web.Constaints;
using BanVeXe_Web.ViewModel.Account;
using BanVeXe_Web.ViewModel.Customer;
using BanVeXe_Web.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.ViewModel.Ticket
{
    public class SummaryBookingViewModel
    {
        public SummaryBookingViewModel( PlaceViewModel departure, PlaceViewModel destionation,
            int adult, int child, DateTime departureDate, bool isReturn)
        {
            //Customer = customer;
            Departure = departure;
            Destination = destionation;
            Adult = adult;
            Child = child;
            DeparDate = departureDate;
            IsReturn = isReturn;
            Tax = Common.TAX;
        }
        //public string CustomerPassport { get; set; }
        public CustomerViewModel Customer { get; set; }

        public bool IsReturn { get; set; }

        public string Class { get; set; }

        public PlaceViewModel Departure { get; set; }

        public PlaceViewModel Destination { get; set; }

        public FlightViewModel DeparFlight { get; set; }

        public FlightViewModel ReturnFlight { get; set; }

        public DateTime DeparDate { get; set; }

        public int Adult { get; set; }

        public int Child { get; set; }

        public decimal Price { get; set; }

        public decimal Tax { get; set; }

        public decimal Total { get; set; }
    }
}
