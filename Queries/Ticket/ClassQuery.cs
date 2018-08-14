using BanVeXe_Web.Models;
using BanVeXe_Web.ViewModel.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.Queries.Ticket
{
    public class ClassQuery
    {
        public static List<ViewModel.Ticket.ClassViewModel> GetClasses(string IdFlight)
        {
            if (!String.IsNullOrEmpty(IdFlight))
            {
                var entity = new QUANLIXEContext();
                try
                {
                    var query = (from d in entity.DeatailClass
                                 join c in entity.Class
                                 on d.IdType equals c.IdType
                                 where d.IdFlight == IdFlight
                                 select new ClassViewModel(d.IdType, c.TypeName, d.Price, d.StartingRow, d.EndingRow)
                               );
                    return query.ToList();
                }
                catch (Exception)
                {
                    entity.Dispose();
                    return new List<ClassViewModel>();
                }
            }
            return new List<ClassViewModel>();
        }
    }
}
