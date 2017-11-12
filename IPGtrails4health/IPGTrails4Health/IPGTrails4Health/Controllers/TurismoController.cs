using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IPGTrails4Health.Models;
using IPGTrails4Health.Models.TurismoViewModels;

namespace IPGTrails4Health.Controllers
{
    public class TurismoController : Controller
    {
        public IActionResult PontosInteresse()
        {
            ViewData["Message"] = "P�gina para adicionar pontos de interesse (fauna, flora, hist�ricos, monumentos) tendo em conta a sazonalidade.";
            return View();
        }
        [HttpGet]
        public IActionResult Extras()
        {
            ViewData["Message"] = "P�gina para inserir alojamento, restaurantes, �reas de descanso, WC ao longo do percurso.";
            return View();
        }
        [HttpPost]
        public ViewResult Extras(ExtrasViewModel extrasviewmodel)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                // guardar dados do extra inserido
                return View();
            }
        }
    }
}