
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Models
{
    public static class DbInitializer
    {
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            TurismoContext dbContext = (TurismoContext)serviceProvider.GetService(typeof(TurismoContext));

            if (!dbContext.Restaurantes.Any())
            {
                EnsureRestaurantesPopulated(dbContext);
            }

            dbContext.SaveChanges();
        }

        private static void EnsureRestaurantesPopulated(TurismoContext dbContext)
        {
            dbContext.Restaurantes.AddRange(
                           new Restaurante
                           {
                               Nome = "Manjar dos Reis",
                               Descricao = "Simplesmente delicioso",
                               Local = "Serra"

                           },
                            new Restaurante
                            {
                                Nome = "Manjar da Rainha",
                                Descricao = "Os melhores preços",
                                Local = "Montanha"

                            },
                           new Restaurante
                           {
                               Nome = "O Cantinho",
                               Descricao = "Os melhores preços",
                               Local = "Montanha"

                           }

            );
        }
        private static void EnsureAlojamentosPopulated(TurismoContext dbContext)
        {
            dbContext.Alojamentos.AddRange(
                           new Alojamento
                           {
                               Tipo = TipoAloj.Hotel,
                               Nome = "Serrano",
                               Descricao = "O melhor",
                               Local = "Seia"

                           },
                            new Alojamento
                            {
                                Tipo = TipoAloj.Hotel,
                                Nome = "O Alto",
                                Descricao = "O mais alto",
                                Local = "Guarda"

                            },
                           new Alojamento
                           {
                               Tipo = TipoAloj.Pensao,
                               Nome = "Pensionista",
                               Descricao = "O barato",
                               Local = "Vale"

                           }

            );
        }
        private static void EnsureAreasDescansoPopulated(TurismoContext dbContext)
        {
            dbContext.AreasDescanso.AddRange(
                           new AreaDescanso
                           {
                               Tipo = TipoArea.ParqueCampismo,
                               Nome = "Parque Verde Campista",
                               Descricao = "Um bom parque para campistas",
                               Local = "Seia"

                           },
                            new AreaDescanso
                            {
                                Tipo = TipoArea.ParqueCampismo,
                                Nome = "Parque Pouca Imaginacao",
                                Descricao = "Um excelente lugar para acampar",
                                Local = "Manteigas"

                            },
                           new AreaDescanso
                           {
                               Tipo = TipoArea.Wc,
                               Nome = "Casa de Banho",
                               Descricao = "Junto à fonte São Simpósio",
                               Local = "Loriga"

                           }

            );
        }
        private static void EnsureTrilhosPopulated(TurismoContext dbContext)
        {
            dbContext.Trilhos.AddRange(
                           new Trilho
                           {
                               Nome = "Primeiro Trilho",
                               Partida = "Go",
                               Chegada = "Stop",
                               Distancia = 2,
                               Duracao = 30,
                               Dificuldade = "Alta",
                               Percurso = "Exemplo",
                               Sazonalidade = "Neve",
                               EstadoTrilho = "Aberto"

                           },
                            new Trilho
                            {
                                Nome = "Segundo Trilho",
                                Partida = "Inicio",
                                Chegada = "Fim",
                                Distancia = 3,
                                Duracao = 25,
                                Dificuldade = "Media",
                                Percurso = "Rapido",
                                Sazonalidade = "Verão",
                                EstadoTrilho = "Aberto"

                            },
                           new Trilho
                           {
                               Nome = "Terceiro Trilho",
                               Partida = "Inicio",
                               Chegada = "Fim",
                               Distancia = 10,
                               Duracao = 11,
                               Dificuldade = "Baixa",
                               Percurso = "Arriba",
                               Sazonalidade = "Todo Ano",
                               EstadoTrilho = "Aberto"

                           }

            );
        }
        private static void EnsurePontosInteressePopulated(TurismoContext dbContext)
        {
            dbContext.PontosInteresse.AddRange(
                           new PontoInteresse
                           {
                               TipoPontoInteresse = "Paisagem",
                               Nome = "Covao da Ametade",
                               Local = "Vale Glaciario do Zezere",
                               Sazonalidade = 1,
                               Observacoes = "Apesar do local estar a uma quota perto dos 1500 metros de altitude, só não está acessível nos dias de inverno mais rigoroso em que as estradas não permitem passagem devido à queda de neve."

                           },
                            new PontoInteresse
                            {
                                TipoPontoInteresse = "Monumento",
                                Nome = "Linhares da Beira",
                                Local = "Linhares da Beira",
                                Sazonalidade = 2,
                                Observacoes = "Nada a dizer"

                            },
                           new PontoInteresse
                           {
                               TipoPontoInteresse = "Monumento",
                               Nome = "Museu do Pao",
                               Local = "Seia na Quinta Fonte do Marrao",
                               Sazonalidade = 3,
                               Observacoes = "Tudo a dizer"

                           }

            );
        }
    }
}
