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
        [RegularExpression(@"[A-Za-z\s]+", ErrorMessage = "Nome Inválido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza um local de partida do Trilho")]
        [RegularExpression(@"[A-Za-z\s]+", ErrorMessage = "Local de Partida Inválido")]
        public string Partida { get; set; }

        [Required(ErrorMessage = "Por favor introduza um local de chegada do Trilho")]
        [RegularExpression(@"[A-Za-z\s]+", ErrorMessage = "Local de Chegada Inválido")]
        public string Chegada { get; set; }

        [Required(ErrorMessage = "Por favor introduza uma distância do Trilho")]
        [Display(Name = "Distância")]
        public decimal Distancia { get; set; }

        [Required(ErrorMessage = "Por favor introduza a duração prevista do Trilho")]
        [Display(Name = "Duração")]
        public decimal Duracao { get; set; }
        
        public Dificuldade Dificuldade { get; set; }
        public int DificuldadeId { get; set; }
       

        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }

        //[Required(ErrorMessage = "Por favor introduza o estado do Trilho")]
        //public string EstadoTrilho { get; set; }

        public int EpocaAnoId { get; set; }
        public EpocaAno EpocaAno { get; set; }

        public int LocalidadeId { get; set; }
        public Localidade Localidade { get; set; }

        //relacionamentos
        public ICollection<RestauranteTrilho> RestaurantesTrilhos { get; set; }
        public ICollection<AlojamentoTrilho> AlojamentoTrilhos { get; set; }
        public ICollection<PontoInteresseTrilho> PontosInteresseTrilhos { get; set; }
        public ICollection<AreaDescansoTrilho> AreasDescansoTrilhos { get; set; }

        public ICollection<EstadoTrilho> EstadosTrilho { get; set; }
        //public ICollection<Restaurante> Restaurantes { get; set; }
    }
}
