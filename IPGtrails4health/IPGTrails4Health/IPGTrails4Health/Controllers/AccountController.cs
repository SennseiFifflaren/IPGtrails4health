using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IPGTrails4Health.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            ViewData["Message"] = "P�gina Login.";
            return View();
        }

        public IActionResult Register()
        {
            ViewData["Message"] = "P�gina de Registo.";
            return View();
        }
    }
}