﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IPGTrails4Health.Models
{
   
    public class Alojamento
    {
        public int AlojamentoId { get; set; }
        [Required(ErrorMessage = "Por favor introduza o nome do alojamento")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor introduza a descrição")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Por favor introduza o contacto")]
        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Telemóvel inválido")]
        public string Contacto { get; set; }
    }
}
