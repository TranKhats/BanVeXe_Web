using BanVeXe_Web.ViewModel.Ticket;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.ViewModel
{
    public class FlightViewModel
    {
        public FlightViewModel()
        {
        }

        //public FlightViewModel(string idFlight,DateTime starting, DateTime ending, TimeSpan flightDetail,
        //    decimal price, int idRoute, string departure, string destination,string idPlane)
        //{
        //    IdFlight = idFlight;
        //    Starting = starting;
        //    Ending = ending;
        //    FlightDetail = flightDetail;
        //    Price = price;
        //    IdRoute = idRoute;
        //    Departure = departure;
        //    Destination = destination;
        //    IdPlane = idPlane;
        //}
        public FlightViewModel(string idFlight, DateTime starting, DateTime ending, TimeSpan flightDetail,
             int idRoute, string departure, string destination, string idPlane, List<ClassViewModel> classes)
        {
            IdFlight = idFlight;
            Starting = starting;
            Ending = ending;
            FlightDetail = flightDetail;
            IdRoute = idRoute;
            Departure = departure;
            Destination = destination;
            IdPlane = idPlane;
            Classes = classes;
        }
        public string IdFlight { get; set; }

        public DateTime Starting { get; set; }

        public DateTime Ending { get; set; }

        public TimeSpan FlightDetail { get; set; }

        //public decimal Price { get; set; }/// <summary>
        /// sai o day
        /// </summary>
        public List<ClassViewModel> Classes { get; set; }

        public int IdRoute { get; set; }

        public string Departure { get; set; }

        public string Destination { get; set; }

        public string IdPlane { get; set; }
    }

    public class SearchFlightViewModel
    {
        [Required]
        public string IdClass { get; set; }

        public string Id { get; set; }

        [Required]
        public string DeparId { get; set; }
        public List<FlightViewModel> DepartureFlights { get; set; }

        [Required]
        public string ReturnId { get; set; }
        public List<FlightViewModel> ReturnFlights { get; set; }

        public SearchFlightViewModel(List<FlightViewModel> depFlights, List<FlightViewModel> retuFlights)
        {
            this.DepartureFlights = depFlights;
            this.ReturnFlights = retuFlights;
        }

        public SearchFlightViewModel() { }
    }
}
