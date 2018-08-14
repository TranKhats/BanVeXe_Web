using BanVeXe_Web.Classes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.ViewModel.Customer
{
    public class CustomerFormViewModel
    {
        [Required]
        [Display(Name = "Title:")]
        public string Sex { get; set; }
        public List<SelectListItem> Sexes { get; } = new List<SelectListItem>()
        {
            new SelectListItem(){Text="Mr",Value="Male"},
            new SelectListItem(){Text="Mrs/Miss",Value="Female"}
        };

        [Required]
        [Display(Name = "Family Name:")]
        public string FamilyName { get; set; }

        [Required]
        [Display(Name = "Middle and Given Name")]
        public string MiddleName { get; set; }

        [Required]
        [MinLength(10),MaxLength(11)]
        [Display(Name = "Phone:")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Address:")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City:")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Region:")]
        public string Region { get; set; }

        [Required]
        [Display(Name = "Province/State:")]
        public string Province { get; set; }

        [Required]
        [EmailAddress]
        //[Display(Name = "Name")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Day of Birth:")]
        public int Day { get; set; }
        public List<SelectListItem> Days { get; } = Enumerable.Range(1, 31).ToList<int>().ConvertAll(d =>
         {
             return new SelectListItem()
             {
                 Text = d.ToString(),
                 Value = d.ToString()
             };
         });

        [Required]
        [Display(Name = "Month")]
        public int Month { get; set; }
        public List<SelectListItem> Months { get; } = Enumerable.Range(1, 12).ToList<int>().ConvertAll(m =>
         {
             return new SelectListItem()
             {
                 Text = m.ToString(),
                 Value = m.ToString()
             };
         });

        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; }
        public List<SelectListItem> Years { get; } 
            = Enumerable.Range(1940, DateTime.Now.Year - 1940 + 1).ToList<int>().ConvertAll(y =>
             {
                 return new SelectListItem()
                 {
                     Text = y.ToString(),
                     Value = y.ToString()
                 };
             });

        [Display(Name = "Passport Number:")]
        public string PassportNumber { get; set; }

        [Display(Name = "Passport Expiry:")]
        public DateTime ExpDay { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Nationality:")]
        public string Nationality { get; set; }
        public List<SelectListItem> Nationalities { get; } = Country.GetCountries().ConvertAll(c =>
        {
            return new SelectListItem()
            {
                Text = c,
                Value = c
            };
        });
    }
}
