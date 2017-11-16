using IPGTrails4Health.Models;
using System;
using System.Linq;
using IPGTrails4Health.Models.TurismoViewModels;

namespace IPGTrails4Health.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TurismoContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            //if (context.Alojamento.Any())
            //{
            //    return;   // DB has been seeded
            //}

            var alojamentos = new AlojamentoViewModel[]
            {
            new AlojamentoViewModel{Tipo=TipoAloj.Hotel,Nome="Serrano",Descricao="O melhor",Local="Seia",PrecoMin=30,PrecoMax=60},
            new AlojamentoViewModel{Tipo=TipoAloj.Hotel,Nome="O Alto",Descricao="O mais alto",Local="Guarda",PrecoMin=50,PrecoMax=90},
            new AlojamentoViewModel{Tipo=TipoAloj.Pensao,Nome="Pensionista",Descricao="O barato",Local="Vale",PrecoMin=20,PrecoMax=40},
            new AlojamentoViewModel{Tipo=TipoAloj.Pousada,Nome="Serrano",Descricao="Para todos",Local="Montanha",PrecoMin=10,PrecoMax=20},
            new AlojamentoViewModel{Tipo=TipoAloj.Rural,Nome="Casa do Campo",Descricao="Casa da tia",Local="Pico",PrecoMin=22,PrecoMax=26},
            new AlojamentoViewModel{Tipo=TipoAloj.Rural,Nome="Mesmo na Serra",Descricao="Comer e beber",Local="Manteigas",PrecoMin=5,PrecoMax=15},
            new AlojamentoViewModel{Tipo=TipoAloj.Rural,Nome="Amigavel",Descricao="Descansem connosco",Local="Loriga",PrecoMin=0,PrecoMax=10},
            };
            foreach (AlojamentoViewModel a in alojamentos)
            {
                context.Alojamento.Add(a);
            }
            context.SaveChanges();

            var areasdescanso = new AreasDescansoViewModel[]
            {
            new AreasDescansoViewModel{Tipo=TipoArea.ParqueCampismo,Nome="Parque Verde Campista",Descricao="Um bom parque para campistas",Local="Seia"},
            new AreasDescansoViewModel{Tipo=TipoArea.ParqueCampismo,Nome="Parque Pouca Imaginacao",Descricao="Um excelente lugar para acampar",Local="Manteigas"},
            new AreasDescansoViewModel{Tipo=TipoArea.Wc,Nome="Casa de banho",Descricao="Junto à fonte São Simpósio",Local="Loriga"},
            };
            foreach (AreasDescansoViewModel d in areasdescanso)
            {
                context.AreasDescanso.Add(d);
            }
            context.SaveChanges();

            var restaurantes = new RestauranteViewModel[]
            {
            new RestauranteViewModel(){Nome="Manjar dos Reis",Descricao="Simplesmente delicioso",Local="Serra"},
            new RestauranteViewModel(){Nome="Manjar da Rainha",Descricao="Os melhores preços",Local="Montanha"},
            new RestauranteViewModel(){Nome="O Cantinho",Descricao="Simplesmente delicioso",Local="Vale"},
            };
            foreach (RestauranteViewModel r in restaurantes)
            {
                context.Restaurante.Add(r);
            }
            context.SaveChanges();
        }
    }
}