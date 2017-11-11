using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models.TurismoViewModels
{
    public class PontosInteresseViewModel
    {
        [Required(ErrorMessage = "Por favor escolha a categoria do ponto de interesse")]
        [RegularExpression("[1-9]+", ErrorMessage = "Por favor escolha a categoria do ponto de interesse")]
        public int PontoInteresse { get; set; }

        [Required(ErrorMessage = "Por favor introduza o nome do ponto de interesse")]
        [RegularExpression(@"[a-zA-Z\s]+", ErrorMessage = "Nome do ponto de interesse inválido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza o local do ponto de interesse")]
        [RegularExpression(@"[a-zA-Z\s]+", ErrorMessage = "Local do ponto de interesse inválido")]
        public string Local { get; set; }

        [Required(ErrorMessage = "Por favor escolha a sazonalidade")]
        [RegularExpression("[1-9]", ErrorMessage = "Por favor escolha a sazonalidade")]
        public int Sazonalidade { get; set; }

        public string Observacoes { get; set; }
    }
}
