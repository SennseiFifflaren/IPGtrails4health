using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public class Restaurante
    {
        public int RestauranteId { get; set; }
        [Required(ErrorMessage = "Por favor introduza o nome do restaurante")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor introduza a descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Por favor introduza o local")]
        public string Local { get; set; }

        public ICollection<Restaurante> Restaurantes { get; set; }
    }
}
