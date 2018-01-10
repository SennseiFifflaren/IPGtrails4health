using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public class EstadoTrilho
    {
       // public int EstadoTrilhoId { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public int TrilhoId { get; set; }
        public Trilho Trilho { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Causa { get; set; }
    }
}
