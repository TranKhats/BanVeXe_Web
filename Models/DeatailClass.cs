using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class DeatailClass
    {
        public string IdFlight { get; set; }
        public string IdType { get; set; }
        public decimal Price { get; set; }
        public int StartingRow { get; set; }
        public int EndingRow { get; set; }

        public Flight IdFlightNavigation { get; set; }
        public Class IdTypeNavigation { get; set; }
    }
}
