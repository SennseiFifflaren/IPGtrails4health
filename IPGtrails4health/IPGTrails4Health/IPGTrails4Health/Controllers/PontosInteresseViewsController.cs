using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPGTrails4Health.Models.PontosInteresseModels;
using Microsoft.AspNetCore.Mvc;

namespace IPGTrails4Health.Controllers
{
    public class PontosInteresseViewsController : Controller
    {
        [HttpGet]

        public ViewResult InserirPontosInteresse()
        {
            ViewData["Message"] = "Página para adicionar pontos de interesse (fauna, flora, históricos, monumentos) tendo em conta a sazonalidade.";
            return View();
        }

        [HttpPost]

        public ViewResult InserirPontosInteresse(InserirPontoInteresse dados)
        {
            if (ModelState.IsValid)
            {
                //Repository.AddGuestResponse(response);
                return View("PontoInteresseInserido", dados);
            }
            else
            {
                return View();
            }
        }


    }
}