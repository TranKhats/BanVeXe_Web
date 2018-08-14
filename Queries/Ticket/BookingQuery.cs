using BanVeXe_Web.Models;
using BanVeXe_Web.ViewModel;
using BanVeXe_Web.ViewModel.Ticket;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanVeXe_Web.Classes;
using BanVeXe_Web.Constaints;
namespace BanVeXe_Web.Queries.Ticket
{
    public class BookingQuery
    {
        public static void AddTicketIntoSummary(ISession session, string idFlight,bool isDeparture)
        {
            var entity = new QUANLIXEContext();
            SummaryBookingViewModel summary = SessionHelper.GetObjFromJson<SummaryBookingViewModel>(session, Common.SESSIONSUMMARY_NAME);
            if (isDeparture)
            {
                summary.DeparFlight = FlightQueries.FindFlight(idFlight);
            }
            else
            {
                summary.ReturnFlight = FlightQueries.FindFlight(idFlight);
            }
            summary.Tax += Common.TAX;
            summary.Price += Common.FEE;
            SessionHelper.SetObjAsJson(session, Common.SESSIONSUMMARY_NAME, summary);
            entity.Dispose();
        }

        public static void RemoveTicketFromSummary(ISession session,bool isDeparture)
        {
            var entity = new QUANLIXEContext();
            SummaryBookingViewModel summary = SessionHelper.GetObjFromJson<SummaryBookingViewModel>(session, Common.SESSIONSUMMARY_NAME);
            if (isDeparture)
            {
                summary.DeparFlight = null;
            }
            else
            {
                summary.ReturnFlight = null;
            }
            summary.Tax -= Common.TAX;
            summary.Price -= Common.FEE;
            SessionHelper.SetObjAsJson(session, Common.SESSIONSUMMARY_NAME, summary);
            entity.Dispose();
        }
    }
}
