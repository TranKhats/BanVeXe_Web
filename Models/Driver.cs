using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Flight = new HashSet<Flight>();
        }

        public string IdDriver { get; set; }
        public string Name { get; set; }

        public ICollection<Flight> Flight { get; set; }
    }
}
