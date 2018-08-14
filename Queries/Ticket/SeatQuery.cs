using BanVeXe_Web.Models;
using BanVeXe_Web.ViewModel.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.Queries.Ticket
{
    public class SeatQuery
    {
        public static SeatsViewModel GetSeatInPlane(string IdPlane)
        {
            var entity = new QUANLIXEContext();
            if (String.IsNullOrEmpty(IdPlane) || entity.Plane.FirstOrDefault(p => p.IdPlane == IdPlane) == null)
            {
                return new SeatsViewModel();
            }

            var plane = entity.Plane.FirstOrDefault(t => t.IdPlane == IdPlane);
            try
            {
                var query = (from p in entity.BookedSeat
                             select new SeatViewModel()
                             {
                                 Col = p.Col,
                                 Row = p.Row,
                                 IdSeat = p.IdSeat
                             }).ToList();
                SeatsViewModel seats = new SeatsViewModel(query, plane.IdPlane, plane.Rows, plane.Cols);
                return seats;
            }
            catch (Exception)
            {
                entity.Dispose();
                return new SeatsViewModel();
            }
            //List<List<SeatsViewModel>> seatMatrix = new List<List<SeatsViewModel>>();
            //VIET HAMF KT VI TRI DO CO GHE TRONG KO
        }

        public static bool IsAvailableSeat(int row,int col,SeatsViewModel seats)
        {
            foreach (var item in seats.UnvaliableSeat)
            {
                if (row == item.Row && col == item.Col)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
