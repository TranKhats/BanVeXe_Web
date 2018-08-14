using System;
using System.Collections.Generic;

namespace BanVeXe_Web.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Ticket = new HashSet<Ticket>();
        }

        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Passport { get; set; }
        public DateTime? PassportExpiry { get; set; }
        public string Sex { get; set; }

        public ICollection<Ticket> Ticket { get; set; }
    }
}
