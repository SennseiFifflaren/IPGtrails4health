using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    
    public class AreaDescanso
    {
        public int AreaDescansoId { get; set; }

        [Required(ErrorMessage = "Por favor introduza o nome da area")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza a descrição")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Localização")]
        public string Localizacao { get; set; }

        public ICollection<AreaDescansoTrilho> AreasDescansoTrilhos { get; set; }

        //public int LocalidadeId { get; set; }
        //public Localidade Localidade { get; set; }
        //public ICollection<AreaDescanso> AreasDescanso { get; set; }
    }
}
