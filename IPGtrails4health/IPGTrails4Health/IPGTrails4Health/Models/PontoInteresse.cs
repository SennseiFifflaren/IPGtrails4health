using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public class PontoInteresse
    {
        public int PontoInteresseId { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }
        public string Local { get; set; }
        public int LocalidadeId { get; set; }
        public Localidade Localidade { get; set; }
        
        public TipoPontoInteresse Tipo { get; set; }
        public int TipoPontoInteresseId { get; set; }
        public ICollection<PontoInteresseTrilho> PontosInteresseTrilhos { get; set; }
    }
}
