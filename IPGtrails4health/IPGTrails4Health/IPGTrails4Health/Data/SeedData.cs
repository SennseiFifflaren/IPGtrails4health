﻿using IPGTrails4Health.Models;
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
                               Local = "Serra"

                           }
            );
        }

        private static void EnsureTrilhosPopulated(TurismoDbContext dbContext)
        {
            dbContext.Trilhos.AddRange(
                           new Trilho
                           {
                               Nome = "Primeiro Trilho",
                               Partida = "Go",
                               Chegada = "Stop",
                               Distancia = 2,
                               Duracao = 30,
                               Percurso = "Exemplo"
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
    }
}
