using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.ViewModel.Home
{
    public class PlaceViewModel
    {
        public PlaceViewModel() { }
        public PlaceViewModel(string idPlace, string placeName, string introduction, string linkImg)
        {
            IdPlace = idPlace;
            PlaceName = placeName;
            Introduction = introduction;
            LinkImg = linkImg;
        }

        public string IdPlace { get; set; }
        public string PlaceName { get; set; }
        public string Introduction { get; set; }
        public string LinkImg { get; set; }
    }
}
