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
        public string Partida { get; set; }

        [Required(ErrorMessage = "Por favor introduza um local de chegada do Trilho")]
        public string Chegada { get; set; }

        [Required(ErrorMessage = "Por favor introduza uma distância do Trilho")]
        public decimal Distancia { get; set; }

        [Required(ErrorMessage = "Por favor introduza a duração prevista do Trilho")]
        public decimal Duracao { get; set; }

        [Required(ErrorMessage = "Por favor introduza a dificuldade do Trilho")]
        public string Dificuldade { get; set; }

        [Required(ErrorMessage = "Por favor introduza o tipo de percurso do Trilho")]
        public string Percurso { get; set; }

        [Required(ErrorMessage = "Por favor introduza a sazonalidade do Trilho")]
        public string Sazonalidade { get; set; }

        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
        //public int EstadoId { get; set; }
        //public Estado TipoEstado { get; set; }

        [Required(ErrorMessage = "Por favor introduza o estado do Trilho")]
        public string EstadoTrilho { get; set; }

        public ICollection<RestauranteTrilho> RestaurantesTrilhos { get; set; }
        //public ICollection<EstadoTrilho> EstadosTrilho { get; set; }
        //public ICollection<Restaurante> Restaurantes { get; set; }
    }
}
