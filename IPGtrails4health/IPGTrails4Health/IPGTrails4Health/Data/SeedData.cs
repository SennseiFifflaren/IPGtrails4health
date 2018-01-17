using IPGTrails4Health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Data
{
    public static class SeedData
    {

        public static void EnsurePopulated(IServiceProvider appServices)
        {
            TurismoDbContext dbContext = (TurismoDbContext)appServices.GetService(typeof(TurismoDbContext));

            if (!dbContext.Restaurantes.Any())
            {
                EnsureRestaurantesPopulated(dbContext);
            }

            if (!dbContext.Trilhos.Any())
            {
                EnsureTrilhosPopulated(dbContext);
            }

            dbContext.SaveChanges();
        }

        private static void EnsureLocalidadesPopulated(TurismoDbContext dbContext)
        {
            dbContext.Localidades.AddRange(
                           new Localidade
                           {
                               Nome = "Guarda",
                               CodigoPostal = "6300"
                           },
                           new Localidade
                           {
                               Nome = "Serra da Estrela",
                               CodigoPostal = "6290"
                           },
                           new Localidade
                           {
                               Nome = "Folgosinho",
                               CodigoPostal = "6290"
                           }

            );
        }

        private static void EnsureAlojamentosPopulated(TurismoDbContext dbContext)
        {

            Localidade localidade1 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Guarda");
            Localidade localidade2 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Serra da Estrela");
            Localidade localidade3 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Folgosinho");

            dbContext.Alojamentos.AddRange(
                           new Alojamento
                           {
                               Nome = "Hotel Reis",
                               Descricao = "O mais completo!",
                               Contacto = "271011222",
                               LocalidadeId = localidade1.LocalidadeId
                           },
                           new Alojamento
                           {
                               Nome = "Pensão Aliança",
                               Descricao = "O mais em conta.",
                               Contacto = "271011222",
                               LocalidadeId = localidade2.LocalidadeId
                           },
                           new Alojamento
                           {
                               Nome = "Residencial Apple",
                               Descricao = "Interessante.",
                               Contacto = "271011222",
                               LocalidadeId = localidade3.LocalidadeId
                           }

            );
        }
        private static void EnsureDificuldadesPopulated(TurismoDbContext dbContext)
        {
            dbContext.Dificuldades.AddRange(
                           new Dificuldade
                           {
                               Nome = "Baixa"
                           },
                           new Dificuldade
                           {
                               Nome = "Média"
                           },
                           new Dificuldade
                           {
                               Nome = "Alta"
                           }

            );
        }
        private static void EnsureEpocasAnoPopulated(TurismoDbContext dbContext)
        {
            dbContext.EpocasAno.AddRange(
                           new EpocaAno
                           {
                               Nome = "Todo ano"
                           },
                           new EpocaAno
                           {
                               Nome = "Só inverno"
                           },
                           new EpocaAno
                           {
                               Nome = "Só verão"
                           }

            );
        }

        private static void EnsureRestaurantesPopulated(TurismoDbContext dbContext)
        {
            Localidade localidade1 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Guarda");
            Localidade localidade2 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Serra da Estrela");
            Localidade localidade3 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Folgosinho");

            dbContext.Restaurantes.AddRange(
                           new Restaurante
                           {
                               Nome = "Manjar dos Reis",
                               Descricao = "Simplesmente delicioso",
                               Contacto = "271011222",
                               LocalidadeId = localidade1.LocalidadeId
                           },
                           new Restaurante
                           {
                               Nome = "Ribos Food Concept",
                               Descricao = "Sublime",
                               Contacto = "273556652",
                               LocalidadeId = localidade2.LocalidadeId
                           },
                           new Restaurante
                           {
                               Nome = "Krom Pro",
                               Descricao = "Elegante",
                               Contacto = "271474112",
                               LocalidadeId = localidade3.LocalidadeId
                           }
            );
        }
        private static void EnsureAreasDescansoPopulated(TurismoDbContext dbContext)
        {

            dbContext.AreasDescanso.AddRange(
                           new AreaDescanso
                           {
                               Nome = "Casa de banho",
                               Descricao = "Para meninos e meninas",
                               DistanciaAteArea = 300
                           },
                           new AreaDescanso
                           {
                               Nome = "Casa de repouso",
                               Descricao = "Com lareira e tudo",
                               DistanciaAteArea = 60
                           },
                           new AreaDescanso
                           {
                               Nome = "Krom Pro",
                               Descricao = "Elegante",
                               DistanciaAteArea = 50
                           }
            );
        }

        private static void EnsureTrilhosPopulated(TurismoDbContext dbContext)
        {
            //Restaurante restaurante1 = dbContext.Restaurantes.SingleOrDefault(r => r.Contacto == "271011222");
            //Restaurante restaurante2 = dbContext.Restaurantes.SingleOrDefault(r => r.Contacto == "273556652");
            //Restaurante restaurante3 = dbContext.Restaurantes.SingleOrDefault(r => r.Contacto == "271474112");

            Dificuldade dificuldade1 = dbContext.Dificuldades.SingleOrDefault(d => d.Nome == "Baixa");
            Dificuldade dificuldade2 = dbContext.Dificuldades.SingleOrDefault(d => d.Nome == "Média");
            Dificuldade dificuldade3 = dbContext.Dificuldades.SingleOrDefault(d => d.Nome == "Alta");

            EpocaAno epocaano1 = dbContext.EpocasAno.SingleOrDefault(e => e.Nome == "Todo ano");
            EpocaAno epocaano2 = dbContext.EpocasAno.SingleOrDefault(e => e.Nome == "Só inverno");
            EpocaAno epocaano3 = dbContext.EpocasAno.SingleOrDefault(e => e.Nome == "Só verão");

            Localidade localidade1 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Guarda");
            Localidade localidade2 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Serra da Estrela");
            Localidade localidade3 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Folgosinho");

            dbContext.Trilhos.AddRange(
                           new Trilho
                           {
                               Nome = "Primeiro Trilho",
                               Partida = "Guarda",
                               Chegada = "Folgosinho",
                               Distancia = 600,
                               Duracao = 30,
                               EpocaAnoId=epocaano1.EpocaAnoId,
                               LocalidadeId=localidade1.LocalidadeId
                           },
                           new Trilho
                           {
                               Nome = "Trilho Grande",
                               Partida = "Covilhã",
                               Chegada = "Folgosinho",
                               Distancia = 2000,
                               Duracao = 180,
                               EpocaAnoId = epocaano2.EpocaAnoId,
                               LocalidadeId = localidade2.LocalidadeId
                           },
                           new Trilho
                           {
                               Nome = "Santo Caminho",
                               Partida = "Guarda",
                               Chegada = "Folgosinho",
                               Distancia = 1500,
                               Duracao = 120,
                               EpocaAnoId = epocaano3.EpocaAnoId,
                               LocalidadeId = localidade3.LocalidadeId
                           }

            );
        }
        private static void EnsureEstadosPopulated(TurismoDbContext dbContext)
        {
            dbContext.Estados.AddRange(
                           new Estado
                           {
                               Nome = "Aberto"
                           },
                           new Estado
                           {
                               Nome = "Fechado"
                           },
                           new Estado
                           {
                               Nome = "Temporariamente suspenso"
                           }

            );
        }
        private static void EnsurePontosInteressePopulated(TurismoDbContext dbContext)
        {
            TipoPontoInteresse tipoponto1 = dbContext.TipoPontosInteresse.SingleOrDefault(t => t.Nome == "Igreja");
            TipoPontoInteresse tipoponto2 = dbContext.TipoPontosInteresse.SingleOrDefault(t => t.Nome == "Estátua");
            TipoPontoInteresse tipoponto3 = dbContext.TipoPontosInteresse.SingleOrDefault(t => t.Nome == "Monumento");

            Localidade localidade1 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Guarda");
            Localidade localidade2 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Serra da Estrela");
            Localidade localidade3 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Folgosinho");

            dbContext.PontosInteresse.AddRange(
                           new PontoInteresse
                           {
                               Nome = "Igreja Secular",
                               Observacoes = "Construída no século XVII a ordem de D. Filipe II",
                               TipoPontoInteresseId = tipoponto1.TipoPontoInteresseId,
                               LocalidadeId = localidade1.LocalidadeId

                           },
                           new PontoInteresse
                           {
                               Nome = "Estátua de Napoleão",
                               Observacoes = "Esculpida em 1888 ",
                               TipoPontoInteresseId = tipoponto2.TipoPontoInteresseId,
                               LocalidadeId = localidade2.LocalidadeId
                           },
                           new PontoInteresse
                           {
                               Nome = "Mosteiro da Serra",
                               Observacoes = "Construída por motivos simbólicos",
                               TipoPontoInteresseId = tipoponto3.TipoPontoInteresseId,
                               LocalidadeId = localidade3.LocalidadeId
                           }

            );
        }
        private static void EnsureTipoPontosInteressePopulated(TurismoDbContext dbContext)
        {


            dbContext.TipoPontosInteresse.AddRange(
                new TipoPontoInteresse
                {
                    Nome = "Igreja"
                },
                new TipoPontoInteresse
                {
                    Nome = "Estátua"
                },
                new TipoPontoInteresse
                {
                    Nome = "Monumento"
                }

            );
        }
    }
}
