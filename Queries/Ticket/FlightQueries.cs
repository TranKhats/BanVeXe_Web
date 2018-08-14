using BanVeXe_Web.Models;
using BanVeXe_Web.Queries.Home;
using BanVeXe_Web.Queries.Ticket;
using BanVeXe_Web.ViewModel;
using BanVeXe_Web.ViewModel.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.Queries.Ticket
{
    public class FlightQueries
    {

        public static FlightViewModel FindFlight(string idFlight)
        {
            var entity = new QUANLIXEContext();
            var flight = entity.Flight.FirstOrDefault(f => f.IdFlight == idFlight);
            if (flight != null)
            {
                var route = entity.Route.FirstOrDefault(r => r.IdRoute == flight.IdRoute);
                string dep = entity.Place.Where(p => p.IdPlace == route.IdDepacture).Select(p => p.Placename).FirstOrDefault();
                string des = entity.Place.Where(p => p.IdPlace == route.IdDestination).Select(p => p.Placename).FirstOrDefault();
                List<ViewModel.Ticket.ClassViewModel> classes = new List<ViewModel.Ticket.ClassViewModel>();
                try
                {
                    var query = (
                                 from d in entity.DeatailClass
                                 join c in entity.Class
                                 on d.IdType equals c.IdType
                                 where d.IdFlight==idFlight
                                 select new ViewModel.Ticket.ClassViewModel(d.IdType,c.TypeName,d.Price,d.StartingRow,d.EndingRow)
                                 );
                    classes = query.ToList();
                }
                catch (Exception)
                {
                    entity.Dispose();
                }

                FlightViewModel res = new FlightViewModel(idFlight, flight.Starting, flight.Ending, flight.FlightDetail,  flight.IdRoute, dep, des, flight.IdPlane,classes);
                return res;
            }
            entity.Dispose();
            return null;
        }

        public static List<FlightViewModel> GetFlights(int idRoute, DateTime start)
        {
            if (idRoute != -1)
            {
                var entity = new QUANLIXEContext();
                var route = entity.Route.FirstOrDefault(r => r.IdRoute == idRoute);
                string dep = entity.Place.Where(p => p.IdPlace == route.IdDepacture).Select(p => p.Placename).FirstOrDefault();
                string des = entity.Place.Where(p => p.IdPlace == route.IdDestination).Select(p => p.Placename).FirstOrDefault();
                try
                {
                    var query = (from f in entity.Flight
                                 where f.IdRoute == idRoute && f.Starting.Date == start.Date
                                 select new FlightViewModel()
                                 {
                                     Starting = f.Starting,
                                     Ending = f.Ending,
                                     IdFlight = f.IdFlight,
                                     FlightDetail = f.FlightDetail,
                                     IdRoute = f.IdRoute,
                                     Departure = dep,
                                     Destination = des,
                                     IdPlane=f.IdPlane,
                                     Classes=ClassQuery.GetClasses(f.IdFlight)
                                 });
                    return query.ToList<FlightViewModel>();
                }
                catch (Exception)
                {
                    //set the erro
                    entity.Dispose();
                    return new List<FlightViewModel>();
                }
            }
            return new List<FlightViewModel>();
        }

        public static SearchFlightViewModel SearchFlights(BookingTiketFormViewModel model)
        {

            int idRouteDep = RouteQueries.GetIdRoute(model.IdDeparture, model.IdDestination);
            List<FlightViewModel> departureFlights = FlightQueries.GetFlights(idRouteDep, model.Start);
            if (model.IsReturn)
            {
                int idRouteReturn = RouteQueries.GetIdRoute(model.IdDestination, model.IdDeparture);
                return new SearchFlightViewModel(departureFlights, FlightQueries.GetFlights(idRouteReturn, model.End));
            }
            return new SearchFlightViewModel(departureFlights, new List<FlightViewModel>());
        }
    }
}
