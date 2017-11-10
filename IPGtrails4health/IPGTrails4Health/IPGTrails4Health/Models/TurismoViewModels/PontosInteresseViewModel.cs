using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models.TurismoViewModels
{
    public class PontosInteresseViewModel
    {
        [Required(ErrorMessage = "Por favor escolha uma opção")]
        public int PontoInteresse { get; set; }

        [Required(ErrorMessage = "Por favor introduza o nome do ponto de interesse")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza o local do ponto de interesse")]
        public string Local { get; set; }

        [Required(ErrorMessage = "Por favor escolha uma opção")]
        public int Sazonalidade { get; set; }
    }
}
