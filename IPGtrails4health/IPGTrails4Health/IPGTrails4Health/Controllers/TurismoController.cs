using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IPGTrails4Health.Controllers
{
    public class TurismoController : Controller
    {
        public IActionResult PontosInteresse()
        {
            ViewData["Message"] = "P�gina para adicionar pontos de interesse (fauna, flora, hist�ricos, monumentos) tendo em conta a sazonalidade.";
            return View();
        }
        public IActionResult Alojamento()
        {
            ViewData["Message"] = "P�gina para inserir alojamento, restaurantes, �reas de descanso, WC ao longo do percurso.";
            return View();
        }
    }
}