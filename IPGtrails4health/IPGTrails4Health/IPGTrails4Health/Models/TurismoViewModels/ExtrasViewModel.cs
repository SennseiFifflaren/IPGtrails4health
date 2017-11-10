using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models.TurismoViewModels
{
    public class ExtrasViewModel
    {
        public string TipoExtra { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public string HorarioFuncionamento { get; set; } // Ex: 9h-13h, 15h-19h
        public string DiasAberto { get; set; } // Ex: Seg-Qua, Sex, Sab
    }
}
