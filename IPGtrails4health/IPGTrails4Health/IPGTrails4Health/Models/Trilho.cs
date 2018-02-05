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

        [StringLength(18, MinimumLength = 3, ErrorMessage = "Nome Invalido")]
        [Required(ErrorMessage = "Por favor introduza o nome do Trilho")]
        [RegularExpression(@"[a-zA-Z0-9záàâãéèêíóôõúçÁÀÂÃÉÈÍÏÓÔÕÚ\s\\._\\-]{3,}", ErrorMessage = "Nome contem caracteres inválidos")]
        public string Nome { get; set; }

        [StringLength(18, MinimumLength = 3, ErrorMessage = "Partida Invalida")]
        [Required(ErrorMessage = "Por favor introduza um local de partida do Trilho")]
        [RegularExpression(@"[a-zA-Z0-9záàâãéèêíóôõúçÁÀÂÃÉÈÍÏÓÔÕÚ\s\\._\\-]{3,}", ErrorMessage = "Partida contem caracteres inválidos")]
        public string Partida { get; set; }

        [StringLength(18, MinimumLength = 3, ErrorMessage = "Chegada Invalida")]
        [Required(ErrorMessage = "Por favor introduza um local de chegada do Trilho")]
        [RegularExpression(@"[a-zA-Z0-9záàâãéèêíóôõúçÁÀÂÃÉÈÍÏÓÔÕÚ\s\\._\\-]{3,}", ErrorMessage = "Chegada contem caracteres inválidos")]
        public string Chegada { get; set; }

        [Range(1, 50, ErrorMessage = "O valor da distancia so pode ser entre 1 e 50")]
        [Required(ErrorMessage = "Por favor introduza uma distância do Trilho")]
        [Display(Name = "Distância")]
        public decimal Distancia { get; set; }

        [Required(ErrorMessage = "Por favor introduza a duração prevista do Trilho")]
        [Display(Name = "Duração")]
        public decimal Duracao { get; set; }
        
        public Dificuldade Dificuldade { get; set; }
        public int DificuldadeId { get; set; }
       

       // public int RestauranteId { get; set; }
       // public Restaurante Restaurante { get; set; }

        //[Required(ErrorMessage = "Por favor introduza o estado do Trilho")]
        //public string EstadoTrilho { get; set; }

        public int EpocaAnoId { get; set; }
        public EpocaAno EpocaAno { get; set; }

        //public int LocalidadeId { get; set; }
        //public Localidade Localidade { get; set; }

        //relacionamentos
        public ICollection<RestauranteTrilho> RestaurantesTrilhos { get; set; }
        public ICollection<AlojamentoTrilho> AlojamentoTrilhos { get; set; }
        public ICollection<PontoInteresseTrilho> PontosInteresseTrilhos { get; set; }
        public ICollection<AreaDescansoTrilho> AreasDescansoTrilhos { get; set; }

        public ICollection<EstadoTrilho> EstadosTrilho { get; set; }
        //public ICollection<Restaurante> Restaurantes { get; set; }
    }
}
