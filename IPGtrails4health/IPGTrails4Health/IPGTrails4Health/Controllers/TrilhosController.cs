using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IPGTrails4Health.Controllers
{
    public class TrilhosController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "P�gina que mostra tudo o que o turista pode fazer.";
            return View();
        }

        public IActionResult VerTrilhos()
        {
            ViewData["Message"] = "P�gina que mostra os Trilhos.";
            return View();
        }
        public IActionResult CriarTrilho()
        {
            ViewData["Message"] = "P�gina para criar Trilhos.";
            return View();
        }
        public IActionResult Feedback()
        {
            ViewData["Message"] = "P�gina para avaliar Trilhos.";
            return View();
        }
    }
}