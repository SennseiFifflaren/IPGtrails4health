using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public class AlojamentoTrilho
    {
        public int AlojamentoTrilhoId { get; set; }

        public int TrilhoId { get; set; }
        public Trilho Trilho { get; set; }

        public int AlojamentoId { get; set; }
        public Alojamento Alojamento { get; set; }

    
    }
}
