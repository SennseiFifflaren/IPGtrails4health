using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IPGTrails4Health.Controllers
{
    public class TrilhosController : Controller
    {
        public IActionResult VerTrilhos()
        {
            ViewData["Message"] = "Página que mostra os Trilhos.";
            return View();
        }
        public IActionResult CriarTrilhos()
        {
            ViewData["Message"] = "Página para criar Trilhos.";
            return View();
        }
    }
}