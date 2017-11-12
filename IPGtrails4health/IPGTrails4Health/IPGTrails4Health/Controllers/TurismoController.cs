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
            ViewData["Message"] = "Página para adicionar pontos de interesse (fauna, flora, históricos, monumentos) tendo em conta a sazonalidade.";
            return View();
        }
        [HttpGet]
        public IActionResult Alojamento()
        {
            ViewData["Message"] = "Página para inserir alojamentos.";
            return View();
        }
        [HttpPost]
        public ViewResult Alojamento(AlojamentoViewModel alojamento)
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

        [HttpGet]
        public IActionResult Restaurante()
        {
            ViewData["Message"] = "Página para inserir restaurantes.";
            return View();
        }
        [HttpPost]
        public ViewResult Restaurante(AlojamentoViewModel restaurante)
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

        [HttpGet]
        public IActionResult AreasDescanso()
        {
            ViewData["Message"] = "Página para inserir áreas de descanso (WC).";
            return View();
        }
        [HttpPost]
        public ViewResult AreasDescanso(AlojamentoViewModel descanso)
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