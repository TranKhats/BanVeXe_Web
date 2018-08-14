using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.ViewModel.Customer
{
    public class CustomerViewModel
    {
        public CustomerViewModel(string name, DateTime birthdate, string passport, string sex)
        {
            Name = name;
            Birthdate = birthdate;
            Passport = passport;
            Sex = sex;
        }

        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Passport { get; set; }
        public string Sex { get; set; }
    }
}
