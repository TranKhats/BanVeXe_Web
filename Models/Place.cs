using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class Place
    {
        public Place()
        {
            RouteIdDepactureNavigation = new HashSet<Route>();
            RouteIdDestinationNavigation = new HashSet<Route>();
        }

        public string IdPlace { get; set; }
        public string Placename { get; set; }
        public string Introduction { get; set; }
        public string LinkImg { get; set; }

        public ICollection<Route> RouteIdDepactureNavigation { get; set; }
        public ICollection<Route> RouteIdDestinationNavigation { get; set; }
    }
}
