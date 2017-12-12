﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    
    public class AreaDescanso
    {
        public int AreaDescansoId { get; set; }
        [Required(ErrorMessage = "Por favor introduza o tipo de area")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Por favor introduza o nome da area")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor introduza a descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Por favor introduza o local")]
        public string Local { get; set; }
        //public ICollection<AreaDescanso> AreasDescanso { get; set; }
    }
}
