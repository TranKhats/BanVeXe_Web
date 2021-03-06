﻿using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class BookedSeat
    {
        public BookedSeat()
        {
            Ticket = new HashSet<Ticket>();
        }

        public string IdSeat { get; set; }
        public string IdFlight { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public string IdType { get; set; }

        public Flight IdFlightNavigation { get; set; }
        public ICollection<Ticket> Ticket { get; set; }
    }
}
