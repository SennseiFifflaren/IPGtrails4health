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
            new Alojamento
            {
                Tipo=TipoAloj.Hotel,
                Nome ="Serrano",
                Descricao ="O melhor",
                Local ="Seia"
            },
            new Alojamento
            {
                Tipo=TipoAloj.Hotel,
                Nome ="O Alto",
                Descricao ="O mais alto",
                Local ="Guarda"
            },
            new Alojamento
            {
                Tipo=TipoAloj.Pensao,
                Nome ="Pensionista",
                Descricao ="O barato",
                Local ="Vale"
            },
            new Alojamento{Tipo=TipoAloj.Pousada,
                Nome="Serrano",
                Descricao ="Para todos",
                Local ="Montanha"
            },
           };
            foreach (Alojamento a in alojamentos)
            {
                context.Alojamentos.Add(a);
            }
            context.SaveChanges();

            var areasdescanso = new AreaDescanso[]
            {
            new AreaDescanso
            {
                Tipo=TipoArea.ParqueCampismo,
                Nome ="Parque Verde Campista",
                Descricao ="Um bom parque para campistas",
                Local ="Seia"
            },
            new AreaDescanso
            {
                Tipo=TipoArea.ParqueCampismo,
                Nome ="Parque Pouca Imaginacao",
                Descricao ="Um excelente lugar para acampar",
                Local ="Manteigas"
            },
            new AreaDescanso{Tipo=TipoArea.Wc,
                Nome ="Casa de banho",
                Descricao ="Junto à fonte São Simpósio",
                Local ="Loriga"
                
            },
            };
            foreach (AreaDescanso ad in areasdescanso)
            {
                context.AreasDescanso.Add(ad);
            }
            context.SaveChanges();

            var restaurantes = new Restaurante[]
            {
            new Restaurante{Nome="Manjar dos Reis",
                Descricao ="Simplesmente delicioso",
                Local ="Serra"
                
            },
            new Restaurante{Nome="Manjar da Rainha",
                Descricao ="Os melhores preços",
                Local ="Montanha"
                
            },
            new Restaurante{Nome="O Cantinho",
                Descricao ="Simplesmente delicioso",
                Local ="Vale"
                
            },
            };
            foreach (Restaurante r in restaurantes)
            {
                context.Restaurantes.Add(r);
            }
            context.SaveChanges();

            var trilhos = new Trilho[]
            {
                new Trilho()
                {
                    Nome="Primeiro Trilho",
                    Partida ="Go",
                    Chegada = "Stop",
                    Distancia = 2,
                    Duracao = 30,
                    Dificuldade = "Alta",
                    Percurso = "Exemplo",
                    Sazonalidade = "Neve",
                    EstadoTrilho = "Aberto"
                },
                new Trilho()
                {
                    Nome="Segundo Trilho",
                    Partida ="Inicio",
                    Chegada = "Fim",
                    Distancia = 3,
                    Duracao = 25,
                    Dificuldade = "Media",
                    Percurso = "Rapido",
                    Sazonalidade = "Verão",
                    EstadoTrilho = "Aberto"
                },
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

                new PontoInteresse
                {
                    TipoPontoInteresse = "Monumento",
                    Nome = "Linhares da Beira",
                    Local = "Linhares da Beira",
                    Sazonalidade = 2,
                    Observacoes = ""
                },

                new PontoInteresse
                {
                    TipoPontoInteresse = "Monumento",
                    Nome = "Museu do Pão",
                    Local = "Seia na Quinta Fonte do Marrão",
                    Sazonalidade = 3,
                    Observacoes = ""
                },


            };
            foreach (PontoInteresse pi in pontosinteresse)
            {
                context.PontosInteresse.Add(pi);
            }
            context.SaveChanges();

        }
    }
}