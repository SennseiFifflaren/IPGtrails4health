using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IPGTrails4Health.Models
{
    public enum TipoAloj
    {
        Hotel,Pensao,Pousada,Rural
    }
    public class Alojamento
    {
        public int AlojamentoId { get; set; }
        [Required(ErrorMessage = "Por favor introduza o tipo de alojamento")]
        public TipoAloj Tipo { get; set; }
        [Required(ErrorMessage = "Por favor introduza o nome do alojamento")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor introduza a descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Por favor introduza o local")]
        public string Local { get; set; }
        //[Required(ErrorMessage = "Por favor introduza o contacto")]
        //public string Contacto { get; set; }
    }
}
