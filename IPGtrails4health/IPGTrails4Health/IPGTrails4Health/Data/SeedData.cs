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

        private static void EnsureRestaurantesPopulated(TurismoDbContext dbContext)
        {
            dbContext.Restaurantes.AddRange(
                           new Restaurante
                           {
                               Nome = "Manjar dos Reis",
                               Descricao = "Simplesmente delicioso",
                               Contacto = "271011222"
                           }
            );
        }

        private static void EnsureTrilhosPopulated(TurismoDbContext dbContext)
        {
            dbContext.Trilhos.AddRange(
                           new Trilho
                           {
                               Nome = "Primeiro Trilho",
                               Partida = "Guarda",
                               Chegada = "Folgosinho",
                               Distancia = 600,
                               Duracao = 30,
                               RestauranteId = 1
                           },
                           new Trilho
                           {
                               Nome = "Trilho Grande",
                               Partida = "Covilhã",
                               Chegada = "Folgosinho",
                               Distancia = 2000,
                               Duracao = 180,
                               RestauranteId = 1
                           },
                           new Trilho
                           {
                               Nome = "Santo Caminho",
                               Partida = "Guarda",
                               Chegada = "Folgosinho",
                               Distancia = 1500,
                               Duracao = 120,
                               RestauranteId = 1
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
        private static void EnsureAlojamentosPopulated(TurismoDbContext dbContext)
        {
            dbContext.Alojamentos.AddRange(
                           new Alojamento
                           {
                               Nome = "Hotel 4 estrelas",
                               Descricao = "Acolhedor",
                               Contacto = "271011555"
                           },
                           new Alojamento
                           {
                               Nome = "Fraco Sono",
                               Descricao = "Camas de solteiro",
                               Contacto = "271011144"
                           },
                           new Alojamento
                           {
                               Nome = "Hotel Pensionista",
                               Descricao = "Castelo em pedra",
                               Contacto = "272014111"
                           }

            );
        }
        private static void EnsurePontosInteressePopulated(TurismoDbContext dbContext)
        {
            dbContext.PontosInteresse.AddRange(
                           new PontoInteresse
                           {
                               Nome = "Hotel 4 estrelas",
                               Observacoes = "Acolhedor"
                           },
                           new PontoInteresse
                           {
                               Nome = "Fraco Sono",
                               Observacoes = "Camas de solteiro"
                           },
                           new PontoInteresse
                           {
                               Nome = "Hotel Pensionista",
                               Observacoes = "Castelo em pedra"
                           }

            );
        }
    }
}
