using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IPGTrails4Health.Models.TrilhosModels;

namespace IPGTrails4Health.Controllers
{
    public class TrilhosController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Página que mostra tudo o que o turista pode fazer.";
            return View();
        }

        public IActionResult VerTrilhos()
        {
            ViewData["Message"] = "Página que mostra os Trilhos.";
            return View();
        }
        [HttpGet]
        public IActionResult CriarTrilho()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CriarTrilho(CriarTrilhoModel criartrilho)
        {
            if (ModelState.IsValid)
            {
                return View("TrilhoCSucesso");
            }
            else
            {
                // There are validation errors
                return View();
            }
        }
        public IActionResult Feedback()
        {
            ViewData["Message"] = "Página para avaliar Trilhos.";
            return View();
        }

    }
}