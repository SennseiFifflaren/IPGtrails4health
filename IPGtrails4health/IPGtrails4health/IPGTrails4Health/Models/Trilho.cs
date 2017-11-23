using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public class Trilho
    {
        public int TrilhoId { get; set; }

        [Required(ErrorMessage = "Por favor introduza o nome do Trilho")]
        [RegularExpression(@"[A-Za-z\s]+",  ErrorMessage = "Nome Inválido")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza um local de partida do Trilho")]
        public int Partida { get; set; }

        [Required(ErrorMessage = "Por favor introduza um local de chegada do Trilho")]
        public int Chegada { get; set; }

        [Required(ErrorMessage = "Por favor introduza uma distância do Trilho")]
        public decimal Distancia { get; set; }

        [Required(ErrorMessage = "Por favor introduza a duração prevista do Trilho")]
        public decimal Duracao { get; set; }

        [Required(ErrorMessage = "Por favor introduza a dificuldade do Trilho")]
        public int Dificuldade { get; set; }

        [Required(ErrorMessage = "Por favor introduza o tipo de percurso do Trilho")]
        public int Percurso { get; set; }

        [Required(ErrorMessage = "Por favor introduza a sazonalidade do Trilho")]
        public int Sazonalidade { get; set; }

        [Required(ErrorMessage = "Por favor introduza o estado do Trilho")]
        public int EstadoTrilho { get; set; }
    }
}
