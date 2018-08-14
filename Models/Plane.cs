using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class Plane
    {
        public Plane()
        {
            Flight = new HashSet<Flight>();
        }

        public string IdPlane { get; set; }
        public string IdType { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }

        public TypePlane IdTypeNavigation { get; set; }
        public ICollection<Flight> Flight { get; set; }
    }
}
