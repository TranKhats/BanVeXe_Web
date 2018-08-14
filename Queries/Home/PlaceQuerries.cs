using BanVeXe_Web.Models;
using BanVeXe_Web.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanVeXe_Web.Queries.Files;

namespace BanVeXe_Web.Queries.Home
{
    public class PlaceQuerries
    {
        public static List<PlaceViewModel> getAllIntroductions()
        {
            var db = new QUANLIXEContext();
            List<PlaceViewModel> lst = new List<PlaceViewModel>();
            try
            {
                lst = (from p in db.Place
                       where p.Introduction != null
                       select new PlaceViewModel()
                       {
                           IdPlace = p.IdPlace,
                           Introduction = FileQuerries.readFile(@"wwwroot\text\" + p.Introduction),
                           PlaceName = p.Placename,
                           LinkImg = p.LinkImg
                       }).ToList<PlaceViewModel>();
                return lst;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static PlaceViewModel GetPlace(string idPlace)
        {
            var entity = new QUANLIXEContext();
            var result = entity.Place.FirstOrDefault(p => p.IdPlace == idPlace);
            return new PlaceViewModel(result.IdPlace, result.Placename, result.Introduction, result.LinkImg);
        }
    }
}
