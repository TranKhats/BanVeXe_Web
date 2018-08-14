using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.ViewModel.Ticket
{
    public class ClassViewModel
    {
        public ClassViewModel()
        {
        }

        public ClassViewModel(string idType, string name, decimal price, int startingRow, int endingRow)
        {
            IdType = idType;
            Name = name;
            Price = price;
            StartingRow = startingRow;
            EndingRow = endingRow;
        }

        public string IdType { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int StartingRow { get; set; }

        public int EndingRow { get; set; }

    }
}
