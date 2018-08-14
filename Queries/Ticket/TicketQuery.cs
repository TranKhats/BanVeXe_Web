using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanVeXe_Web.Classes;
using BanVeXe_Web.ViewModel.Ticket;
using Microsoft.AspNetCore.Http;
using BanVeXe_Web.Constaints;
using BanVeXe_Web.Models;

namespace BanVeXe_Web.Queries.Ticket
{
    public class TicketQuery
    {
        public static void BookTicket(string IdSeat, ISession session)
        {
            if (!String.IsNullOrEmpty(IdSeat))
            {
                var cart = SessionHelper.GetObjFromJson<SummaryBookingViewModel>(session, Common.SESSIONSUMMARY_NAME);
                var entity = new QUANLIXEContext();
                var ticket = new Models.Ticket()
                {
                    IdSeat = IdSeat,
                    IdCus = cart.Customer.Passport,
                    //Export=
                };
            }
        }
    }
}
