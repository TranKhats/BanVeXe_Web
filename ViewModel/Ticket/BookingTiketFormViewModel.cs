using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BanVeXe_Web.Classes;
using BanVeXe_Web.Queries.Home;

namespace BanVeXe_Web.ViewModel.Ticket
{
    public class BookingTiketFormViewModel
    {
        [Required(ErrorMessage = "You must input the departure")]
        [Display(Name = "Departure")]
        public string IdDeparture { get; set; }
        public List<SelectListItem> Departures { get; set; }

        [Required(ErrorMessage = "You must input the destination")]
        [Display(Name = "Destination")]
        public string IdDestination { get; set; }
        public List<SelectListItem> Destinations { get; set; }

        [Required]
        [Display(Name = "Outbout Flight")]
        public DateTime Start { get; set; }

        [Required]
        [Display(Name = "Return Flight")]
        public DateTime End { get; set; }

        [Required]
        [Display(Name = "Adults")]
        public int Adult { get; set; }

        [Display(Name = "Children")]
        public int Child { get; set; }

        [Required]
        public bool IsReturn { get; set; }

        public BookingTiketFormViewModel()
        {
            IsReturn = false;
            Adult = 1;
            Start = DateTime.Now;
            End = this.Start;
            Departures = RouteQueries.GetAllDeparture();
            if (Departures.Count==0)
            {
                Destinations = null;
            }
            else
            {
                Destinations = RouteQueries.GetDestOfDeparture(Departures[0].Value);
            }
        }
    }
}
