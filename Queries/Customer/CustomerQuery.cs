using BanVeXe_Web.Models;
using BanVeXe_Web.ViewModel.Account;
using BanVeXe_Web.ViewModel.Customer;
using BanVeXe_Web.ViewModel.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.Queries.Customer
{
    public class CustomerQuery
    {
        public static void Register(CustomerFormViewModel model)
        {
            var entity = new QUANLIXEContext();
            if (entity.Customer.FirstOrDefault(c => c.Passport == model.PassportNumber) == null)
            {
                entity.Customer.Add(new Models.Customer()
                {
                    Address = model.Address,
                    Birthdate = new DateTime(model.Year, model.Month, model.Day),
                    City = model.City,
                    Email = model.Email,
                    Name = model.FamilyName + model.MiddleName,
                    Passport = model.PassportNumber,
                    PassportExpiry = model.ExpDay,
                    Phone = model.Phone,
                    Sex = model.Sex
                });
                entity.SaveChanges();
            }
            entity.Dispose();
        }
    }
}
