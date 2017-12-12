using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public class ITurismoRepository
    {
        IEnumerable<Trilho> Trilhos { get; }
        IEnumerable<Restaurante> Restaurantes { get; }
    }
}
