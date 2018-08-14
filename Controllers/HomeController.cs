using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BanVeXe_Web.Models;
using BanVeXe_Web.ViewModel;
using BanVeXe_Web.ViewModel.Ticket;
using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Collections.Generic;
using BanVeXe_Web.Queries.Home;

namespace BanVeXe_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new BookingTiketFormViewModel());
        }

        [HttpPost]
        public IActionResult GetDestinations(string IdDeparture)
        {
            var destinationLst = RouteQueries.GetDestOfDeparture(IdDeparture);
            return Json(destinationLst);
        }

    }
}
