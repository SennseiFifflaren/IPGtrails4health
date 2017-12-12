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
            ApplicationDbContext dbContext = (ApplicationDbContext)appServices.GetService(typeof(ApplicationDbContext));

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

        private static void EnsureRestaurantesPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Restaurantes.AddRange(
                           new Restaurante
                           {
                               Nome = "Manjar dos Reis",
                               Descricao = "Simplesmente delicioso",
                               Local = "Serra"

                           }
            );
        }

        private static void EnsureTrilhosPopulated(ApplicationDbContext dbContext)
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

                           }
            );
        }
    }
}
