using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string Nome { get; set; }

        public ICollection<EstadoTrilho> EstadosTrilho { get; set; }
    }
}
