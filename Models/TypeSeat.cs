using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class TypeSeat
    {
        public TypeSeat()
        {
            VariableSeat = new HashSet<VariableSeat>();
        }

        public string IdType { get; set; }
        public string TypeName { get; set; }
        public decimal Price { get; set; }

        public ICollection<VariableSeat> VariableSeat { get; set; }
    }
}
