using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class BuyService
    {
        public string IdTicket { get; set; }
        public string IdService { get; set; }
        public int? Amount { get; set; }

        public Service IdServiceNavigation { get; set; }
        public Ticket IdTicketNavigation { get; set; }
    }
}
