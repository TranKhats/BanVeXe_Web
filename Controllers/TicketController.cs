using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanVeXe_Web.Migrations;
using BanVeXe_Web.Models;
using BanVeXe_Web.Queries.Ticket;
using BanVeXe_Web.ViewModel.Account;
using BanVeXe_Web.ViewModel.Ticket;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BanVeXe_Web.Queries;
using BanVeXe_Web.Classes;
using BanVeXe_Web.Constaints;
using BanVeXe_Web.ViewModel;
using BanVeXe_Web.ViewModel.Customer;
using BanVeXe_Web.Queries.Customer;
using BanVeXe_Web.Queries.Home;

namespace BanVeXe_Web.Controllers
{
    public class TicketController : Controller
    {
        [HttpPost]
        public IActionResult FindFlights(BookingTiketFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = FlightQueries.SearchFlights(model);
                SummaryBookingViewModel cart = new SummaryBookingViewModel(PlaceQuerries.GetPlace(model.IdDeparture),
                                                PlaceQuerries.GetPlace(model.IdDestination),
                                                model.Adult, model.Child, model.Start, model.IsReturn);
                SessionHelper.SetObjAsJson(HttpContext.Session, Common.SESSIONSUMMARY_NAME, cart);
                ViewBag.Summary = cart;
                return View(result);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ChooseFlight(SearchFlightViewModel model)
        {
            ///chỗ ni còn sai------> kiểm tra điều kiện
            var cart = SessionHelper.GetObjFromJson<SummaryBookingViewModel>(HttpContext.Session, Common.SESSIONSUMMARY_NAME);
            cart.Class = model.IdClass;
            SessionHelper.SetObjAsJson(HttpContext.Session, Common.SESSIONSUMMARY_NAME, cart);
            BookingQuery.AddTicketIntoSummary(HttpContext.Session, model.DeparId, true);
            BookingQuery.AddTicketIntoSummary(HttpContext.Session, model.ReturnId, false);
            return RedirectToAction("FillImformation");
        }

        public IActionResult FillImformation()
        {
            var cart = SessionHelper.GetObjFromJson<SummaryBookingViewModel>(HttpContext.Session, Common.SESSIONSUMMARY_NAME);
            ViewBag.Summary = cart;
            CustomerFormViewModel model = new CustomerFormViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult RegisterImformation(CustomerFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cart = SessionHelper.GetObjFromJson<SummaryBookingViewModel>(HttpContext.Session, Common.SESSIONSUMMARY_NAME);
               cart.Customer = new CustomerViewModel(model.FamilyName + model.MiddleName, new DateTime(model.Year, model.Month, model.Day), model.PassportNumber, model.Sex);
                SessionHelper.SetObjAsJson(HttpContext.Session, Common.SESSIONSUMMARY_NAME, cart);

                CustomerQuery.Register(model);
                return RedirectToAction("ChooseSeat");
            }
            return RedirectToAction("FillImformation");
        }

        public IActionResult ChooseSeat()
        {
            var cart = SessionHelper.GetObjFromJson<SummaryBookingViewModel>(HttpContext.Session, Common.SESSIONSUMMARY_NAME);
            var model = SeatQuery.GetSeatInPlane(FlightQueries.FindFlight(cart.DeparFlight.IdFlight).IdPlane);
            ViewBag.Summary = cart;
            return View(model);
        }

        [HttpPost]
        public IActionResult CheckBusySeat()
        {
            var cart = SessionHelper.GetObjFromJson<SummaryBookingViewModel>(HttpContext.Session, Common.SESSIONSUMMARY_NAME);
            var people = cart.Adult + cart.Child;
            return Json(people);
        }

        public IActionResult Pagination()
        {
            var entity = new QUANLIXEContext();
            var result = entity.Account.ToList();
            var model = result.ToPagedList(1, 3);
            return View(model);
        }


    }
}