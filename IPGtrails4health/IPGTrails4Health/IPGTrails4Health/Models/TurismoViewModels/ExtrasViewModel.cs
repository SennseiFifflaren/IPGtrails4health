using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IPGTrails4Health.Models.TurismoViewModels
{
    public class ExtrasViewModel
    {
        [Required(ErrorMessage = "Por favor introduza o tipo")]
        public string TipoExtra { get; set; } //WC, Restaurante, Alojamento
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor introduza a descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Por favor introduza o local")]
        public string Local { get; set; }
        [Required(ErrorMessage = "Por favor introduza o horário de funcionamento")]
        public string HorarioInicio { get; set; }
        [Required(ErrorMessage = "Por favor introduza o horário de funcionamento")]
        public string HorarioFim { get; set; }
        [Required(ErrorMessage = "Por favor introduza os dias que está aberto")]
        public string DiasAberto { get; set; } // Ex: Seg-Qua, Sex, Sab
    }
}
