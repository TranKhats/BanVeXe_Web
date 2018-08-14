using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanVeXe_Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BanVeXe_Web.Controllers
{
    public class TryController : Controller
    {
        public IActionResult ATagForm()
        {
            return View();
        }

        [HttpPost]
        //[MultipleButton(Name = "action", Argument = "Save")]
        public IActionResult AtagForm2(TryViewModel model)
        {
            var req = Request.Form["TrySubmit1"];
             return View();
        }

        public IActionResult PassDataToAction()
        {
            return RedirectToAction("Retrieve", "Try", new { id = 5 });
        }

        public IActionResult Retrieve(int id)
        {
            var x = id;
            return View();//no view, debug here to see
        }

        public IActionResult AHalfForm()
        {
            return View(new TryViewModel());
        }

        [HttpPost]
        public IActionResult AHalfForm(TryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var x = 1;
            }
            return View();
        }

        public IActionResult FistAction()
        {
            return View();
        }

        public IActionResult ReDirect()
        {
            return RedirectToAction("DestinationAction","Try");
        }

        public IActionResult DestinationAction()
        {
            return View("DestinationAction");
        }

        public IActionResult RadioButtonAction()
        {
            AppDTO model = new AppDTO() { Role = 2 };
            List<RoleEum> roles = new List<RoleEum>() {
                new RoleEum(){  Id=1, RoleName="R1"},
                new RoleEum(){  Id=2, RoleName="R2"},
                new RoleEum(){  Id=3, RoleName="R3"}
            };
            ViewBag.Roles = roles;
            return View(model);
        }

        [HttpPost]
        public IActionResult RadioButtonAction1(AppDTO model)
        {
            return View();
        }

        public IActionResult Facebook_Social()
        {
            return View();
        }
    }
}