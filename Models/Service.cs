using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class Service
    {
        public Service()
        {
            BuyService = new HashSet<BuyService>();
        }

        public string IdService { get; set; }
        public string Servicename { get; set; }
        public string Explanation { get; set; }
        public decimal? Price { get; set; }

        public ICollection<BuyService> BuyService { get; set; }
    }
}
