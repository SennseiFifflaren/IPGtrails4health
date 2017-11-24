using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public class PontoInteresseTrilho
    {
        public int PontoInteresseTrilhoId { get; set; }

        public int PontoInteresseId { get; set; }
        public PontoInteresse PontoInteresse { get; set; }

        public int TrilhoId { get; set; }
        public Trilho Trilho { get; set; }
    }
}
