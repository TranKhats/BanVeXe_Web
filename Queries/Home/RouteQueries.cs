using BanVeXe_Web.Models;
using BanVeXe_Web.ViewModel;
using BanVeXe_Web.ViewModel.Home;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.Queries.Home
{
    public class RouteQueries
    {

        public static List<SelectListItem> GetAllDeparture()
        {
            QUANLIXEContext context = new QUANLIXEContext();

            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                var query = (from p in context.Place
                             select new SelectListItem()
                             {
                                 Value = p.IdPlace.ToString(),
                                 Text = p.Placename
                             }
                              );
                list = query.ToList<SelectListItem>();
            }
            catch (Exception)
            {
                context.Dispose();
            }
            return list;
        }

        public static List<SelectListItem> GetDestOfDeparture(string idDeparture)
        {
            QUANLIXEContext context = new QUANLIXEContext();
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                var query = (from r in context.Route
                             join p in context.Place
                             on r.IdDestination equals p.IdPlace
                             where r.IdDepacture == idDeparture
                             select new SelectListItem()
                             {
                                 Value = p.IdPlace,
                                 Text = p.Placename
                             }
                              );
                list = query.ToList<SelectListItem>();
            }
            catch (Exception)
            {
                context.Dispose();
            }
            return list;
        }

        public static int GetIdRoute(string IdDep,string IdDes)
        {
            var entity = new QUANLIXEContext();
            var result = entity.Route.Where(r => r.IdDepacture == IdDep && r.IdDestination == IdDes)
                            .Select(r => r.IdRoute).ToList();
            if (result.Count==0)
            {
                return -1;
            }
            return result.FirstOrDefault();
        }
    }
}
