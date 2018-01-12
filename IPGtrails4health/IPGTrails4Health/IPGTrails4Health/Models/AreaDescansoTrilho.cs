using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public class AreaDescansoTrilho
    {
        public int AreaDescansoTrilhoId { get; set; }
        public int TrilhoId { get; set; }
        public Trilho Trilho { get; set; }
        public int AreaDescansoId { get; set; }
        public AreaDescanso AreaDescanso{ get; set; }
    }
}
