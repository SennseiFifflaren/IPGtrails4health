using IPGTrails4Health.Models;
using System;
using System.Linq;

namespace IPGTrails4Health.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TurismoContext context)
        {
            context.Database.EnsureCreated();


            if (context.Alojamentos.Any())
            {
                return;   // DB has been seeded
            }

            var alojamentos = new Alojamento[]
            {
            new Alojamento{Tipo=TipoAloj.Hotel,Nome="Serrano",Descricao="O melhor",Local="Seia"},
            };
            foreach (Alojamento a in alojamentos)
            {
                context.Alojamentos.Add(a);
            }
            context.SaveChanges();

            var areasdescanso = new AreaDescanso[]
            {
            new AreaDescanso{Tipo=TipoArea.ParqueCampismo,Nome="Parque Verde Campista",Descricao="Um bom parque para campistas",Local="Seia"},
            };
            foreach (AreaDescanso d in areasdescanso)
            {
                context.AreasDescanso.Add(d);
            }
            context.SaveChanges();

            var restaurantes = new Restaurante[]
            {
            new Restaurante{Nome="Manjar dos Reis",Descricao="Simplesmente delicioso",Local="Serra"},
             };
            foreach (Restaurante r in restaurantes)
            {
                context.Restaurantes.Add(r);
            }
            context.SaveChanges();

            var trilhos = new Trilho[]
            {
                new Trilho(){
                    RestauranteId=1,AlojamentoId=1,AreaDescansoId=1,PontoInteresseId=1,
                    Nome="Trilho",Partida="Go",Chegada = "Stop",Distancia = 2,Duracao = 30,Dificuldade = "Alta",Percurso = "Rapido",Sazonalidade = "Neve",EstadoTrilho = "aberto"},
            };
            foreach (Trilho t in trilhos)
            {
                context.Trilhos.Add(t);
            }
            context.SaveChanges();

            var pontosinteresse = new PontoInteresse[]
           {
                new PontoInteresse
                {
                    TipoPontoInteresse = "Paisagem",
                    Nome = "Covão da Ametade",
                    Local = "Vale Glaciário do Zêzere",
                    Sazonalidade = 1,
                    Observacoes = "Apesar do local estar a uma quota perto dos 1500 metros de altitude, só não está acessível nos dias de inverno mais rigoroso em que as estradas não permitem passagem devido à queda de neve."
                },
           };
            foreach (PontoInteresse a in pontosinteresse)
            {
                context.PontosInteresse.Add(a);
            }
            context.SaveChanges();

        }
    }
}