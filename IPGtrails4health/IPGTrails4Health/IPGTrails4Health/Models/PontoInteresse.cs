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
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string Sazonalidade { get; set; }
        public string Observacoes { get; set; }
    }
}
