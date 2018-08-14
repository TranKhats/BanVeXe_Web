using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            BuyService = new HashSet<BuyService>();
        }

        public string IdTicket { get; set; }
        public string IdCus { get; set; }
        public string IdSeat { get; set; }
        public DateTime Export { get; set; }

        public Customer IdCusNavigation { get; set; }
        public BookedSeat IdSeatNavigation { get; set; }
        public ICollection<BuyService> BuyService { get; set; }
    }
}
