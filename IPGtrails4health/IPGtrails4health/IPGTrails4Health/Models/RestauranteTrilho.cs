using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public class RestauranteTrilho
    {
        public int TrilhoId { get; set; }
        public Trilho Trilho { get; set; }
        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }

    }
}
