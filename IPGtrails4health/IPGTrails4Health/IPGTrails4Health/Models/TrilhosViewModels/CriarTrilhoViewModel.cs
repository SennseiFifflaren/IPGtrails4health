using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models.TrilhosViewModels
{
    public class CriarTrilhoViewModel
    {
        public String Nome { get; set; }
        public String Partida { get; set; }
        public String Chegada { get; set; }
        public int Distancia { get; set; }
        public int Dificuldade { get; set; }
        public bool Percurso { get; set; }

    }
}
