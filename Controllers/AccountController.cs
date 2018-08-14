using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BanVeXe_Web.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using BanVeXe_Web.Queries.Account;

namespace BanVeXe_Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool logged = AcountQueries.Login(model.UserName, model.PassWord);
                if (logged)
                {
                    HttpContext.Session.SetString("IsLogged", model.UserName);
                }
                return View("../Home/ActionA");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}