using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class TypeBus
    {
        public TypeBus()
        {
            Plane = new HashSet<Plane>();
        }

        public string IdType { get; set; }
        public string Typename { get; set; }

        public ICollection<Plane> Plane { get; set; }
    }
}
