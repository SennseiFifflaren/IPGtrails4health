using IPGTrails4Health.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public class EFTurismoRepository : ITurismoRepository
    {
        private ApplicationDbContext context;
        public EFTurismoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Trilho> Products => context.Trilhos;
        public IEnumerable<Restaurante> Restaurantes => context.Restaurantes;
    }
}
