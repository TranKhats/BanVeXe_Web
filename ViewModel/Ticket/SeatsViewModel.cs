using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.ViewModel.Ticket
{
    public class SeatsViewModel
    {
        public SeatsViewModel(List<SeatViewModel> chairMatrix, string idFlight, int rows, int cols)
        {
            UnvaliableSeat = chairMatrix;
            IdPlane = idFlight;
            Rows = rows;
            Cols = cols;
        }

        public SeatsViewModel() { }

        //List<List<int>> ChairMatrix { get; set; }//ASDFGHJKL;
        public List<SeatViewModel> UnvaliableSeat { get; set; }
        public string IdPlane { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
    }

    public class SeatViewModel
    {
        public string IdSeat { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
