using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPGTrails4Health.Models.TurismoViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IPGTrails4Health.Controllers
{
    public class TurismoController : Controller
    {
        [HttpGet]

        public ViewResult PontosInteresse()
        {
            ViewData["Message"] = "P�gina para adicionar pontos de interesse (fauna, flora, hist�ricos, monumentos) tendo em conta a sazonalidade.";
            return View();
        }

        [HttpPost]

        public ViewResult PontosInteresse(PontosInteresseViewModel dados)
        {
            if (ModelState.IsValid)
            {
                //Repository.AddGuestResponse(response);
                return View("Inserido", dados);
            }
            else
            {
                return View();
            }
        }


        public IActionResult Extras()
        {
            ViewData["Message"] = "P�gina para inserir alojamento, restaurantes, �reas de descanso, WC ao longo do percurso.";
            return View();
        }
    }
}