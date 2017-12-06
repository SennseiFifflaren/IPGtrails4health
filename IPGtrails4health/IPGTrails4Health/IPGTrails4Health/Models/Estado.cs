using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public enum TipoEstado
    {
        Aberto,Fechado
    }
    public class Estado 
    {
        public int EstadoId { get; set; }
        //public TipoEstado EstadoTrilho { get; set; }

        //public ICollection<Trilho> Trilhos { get; set; }
        //public ICollection<Trilho> EstadosTrilho { get; set; }
    }
}
