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

            if (!dbContext.Localidades.Any())
            {
                EnsureLocalidadesPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.TipoPontosInteresse.Any())
            {
                EnsureTipoPontosInteressePopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.TipoAlojamentos.Any())
            {
                EnsureTiposAlojamentoPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.EpocasAno.Any())
            {
                EnsureEpocasAnoPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.Dificuldades.Any())
            {
                EnsureDificuldadesPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.Estados.Any())
            {
                EnsureEstadosPopulated(dbContext);
                dbContext.SaveChanges();
            }

            if (!dbContext.Alojamentos.Any())
            {
                EnsureAlojamentosPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.Restaurantes.Any())
            {
                EnsureRestaurantesPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.AreasDescanso.Any())
            {
                EnsureAreasDescansoPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.PontosInteresse.Any())
            {
                EnsurePontosInteressePopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.Trilhos.Any())
            {
                EnsureTrilhosPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.RestaurantesTrilhos.Any())
            {
                EnsureRestaurantesTrilhosPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.AlojamentosTrilhos.Any())
            {
                EnsureAlojamentosTrilhosPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.AreasDescansoTrilhos.Any())
            {
                EnsureAreasDescansoTrilhosPopulated(dbContext);
                dbContext.SaveChanges();
            }
            if (!dbContext.PontosInteresseTrilho.Any())
            {
                EnsurePontosInteresseTrilhosPopulated(dbContext);
                dbContext.SaveChanges();
            }

            if (!dbContext.EstadosTrilho.Any())
            {
                EnsureEstadosTrilhosPopulated(dbContext);
                dbContext.SaveChanges();
            }
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
            TipoAlojamento tipoaloj1 = dbContext.TipoAlojamentos.SingleOrDefault(ta => ta.Nome == "Hotel");
            TipoAlojamento tipoaloj2 = dbContext.TipoAlojamentos.SingleOrDefault(ta => ta.Nome == "Pensão");
            TipoAlojamento tipoaloj3 = dbContext.TipoAlojamentos.SingleOrDefault(ta => ta.Nome == "Residencial");

            Localidade localidade1 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Guarda");
            Localidade localidade2 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Serra da Estrela");
            Localidade localidade3 = dbContext.Localidades.SingleOrDefault(l => l.Nome == "Folgosinho");

            dbContext.Alojamentos.AddRange(
                           new Alojamento
                           {
                               Nome = "Hotel Reis",
                               Descricao = "O mais completo!",
                               Contacto = "271011111",
                               LocalidadeId = localidade1.LocalidadeId,
                               TipoAlojamentoId =  tipoaloj1.TipoAlojamentoId
                           },
                           new Alojamento
                           {
                               Nome = "Pensão Aliança",
                               Descricao = "O mais em conta.",
                               Contacto = "271011222",
                               LocalidadeId = localidade2.LocalidadeId,
                               TipoAlojamentoId = tipoaloj2.TipoAlojamentoId
                           },
                           new Alojamento
                           {
                               Nome = "Residencial Apple",
                               Descricao = "Interessante.",
                               Contacto = "271011333",
                               LocalidadeId = localidade3.LocalidadeId,
                               TipoAlojamentoId = tipoaloj3.TipoAlojamentoId
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
                               Localizacao = "Rua xyz, junto à capela de S. Vicente"
                           },
                           new AreaDescanso
                           {
                               Nome = "Casa de repouso",
                               Descricao = "Com lareira e tudo",
                               Localizacao = "Rua 343, junto à Estrada Nacional 20"
                           },
                           new AreaDescanso
                           {
                               Nome = "Parque Campismo",
                               Descricao = "Para aproveitar o exterior",
                               Localizacao = "Coordenadas gps: 41.40338, 2.17403"
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
            

            dbContext.Trilhos.AddRange(
                           new Trilho
                           {
                               Nome = "Primeiro Trilho",
                               Partida = "Guarda",
                               Chegada = "Folgosinho",
                               Distancia = 600,
                               Duracao = 30,
                               EpocaAnoId=epocaano1.EpocaAnoId,
                               DificuldadeId=dificuldade1.DificuldadeId
                           },
                           new Trilho
                           {
                               Nome = "Trilho Grande",
                               Partida = "Covilhã",
                               Chegada = "Folgosinho",
                               Distancia = 2000,
                               Duracao = 180,
                               EpocaAnoId = epocaano2.EpocaAnoId,
                               DificuldadeId = dificuldade2.DificuldadeId
                           },
                           new Trilho
                           {
                               Nome = "Santo Caminho",
                               Partida = "Guarda",
                               Chegada = "Folgosinho",
                               Distancia = 1500,
                               Duracao = 120,
                               EpocaAnoId = epocaano3.EpocaAnoId,
                               DificuldadeId = dificuldade3.DificuldadeId
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
        private static void EnsureTiposAlojamentoPopulated(TurismoDbContext dbContext)
        {


            dbContext.TipoAlojamentos.AddRange(
                new TipoAlojamento
                {
                    Nome = "Hotel"
                },
                new TipoAlojamento
                {
                    Nome = "Pensão"
                },
                new TipoAlojamento
                {
                    Nome = "Residencial"
                }

            );
        }
        private static void EnsureRestaurantesTrilhosPopulated(TurismoDbContext dbContext)
        {
            Restaurante restaurante1 = dbContext.Restaurantes.SingleOrDefault(r => r.Contacto == "271011222");
            Restaurante restaurante2 = dbContext.Restaurantes.SingleOrDefault(r => r.Contacto == "273556652");
            Restaurante restaurante3 = dbContext.Restaurantes.SingleOrDefault(r => r.Contacto == "271474112");

            Trilho trilho1 = dbContext.Trilhos.SingleOrDefault(t => t.Distancia == 600);
            Trilho trilho2 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Trilho Grande");
            Trilho trilho3 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Santo Caminho");

            dbContext.RestaurantesTrilhos.AddRange(
                new RestauranteTrilho
                {
                    RestauranteId = restaurante1.RestauranteId,
                    TrilhoId = trilho1.TrilhoId
                },
                new RestauranteTrilho
                {
                    RestauranteId = restaurante2.RestauranteId,
                    TrilhoId = trilho2.TrilhoId
                },
                new RestauranteTrilho
                {
                    RestauranteId = restaurante3.RestauranteId,
                    TrilhoId = trilho3.TrilhoId
                }

            );
        }
        private static void EnsureAlojamentosTrilhosPopulated(TurismoDbContext dbContext)
        {
            Alojamento aloj1 = dbContext.Alojamentos.SingleOrDefault(a => a.Contacto == "271011111");
            Alojamento aloj2 = dbContext.Alojamentos.SingleOrDefault(a => a.Contacto == "271011222");
            Alojamento aloj3 = dbContext.Alojamentos.SingleOrDefault(a => a.Contacto == "271011333");

            Trilho trilho1 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Primeiro Trilho");
            Trilho trilho2 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Trilho Grande");
            Trilho trilho3 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Santo Caminho");

            dbContext.AlojamentosTrilhos.AddRange(
                new AlojamentoTrilho
                {
                   AlojamentoId = aloj1.AlojamentoId,
                    TrilhoId = trilho1.TrilhoId
                },
                new AlojamentoTrilho
                {
                    AlojamentoId = aloj2.AlojamentoId,
                    TrilhoId = trilho2.TrilhoId
                },
                new AlojamentoTrilho
                {
                    AlojamentoId = aloj3.AlojamentoId,
                    TrilhoId = trilho3.TrilhoId
                }

            );
        }
        private static void EnsureAreasDescansoTrilhosPopulated(TurismoDbContext dbContext)
        {
            AreaDescanso area1 = dbContext.AreasDescanso.SingleOrDefault(ar => ar.Nome == "Casa de banho");
            AreaDescanso area2 = dbContext.AreasDescanso.SingleOrDefault(ar => ar.Nome == "Casa de repouso");
            AreaDescanso area3 = dbContext.AreasDescanso.SingleOrDefault(ar => ar.Nome == "Parque Campismo");

            Trilho trilho1 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Primeiro Trilho");
            Trilho trilho2 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Trilho Grande");
            Trilho trilho3 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Santo Caminho");

            dbContext.AreasDescansoTrilhos.AddRange(
                new AreaDescansoTrilho
                {
                    AreaDescansoId = area1.AreaDescansoId,
                    TrilhoId = trilho1.TrilhoId
                },
                new AreaDescansoTrilho
                {
                    AreaDescansoId = area2.AreaDescansoId,
                    TrilhoId = trilho2.TrilhoId
                },
                new AreaDescansoTrilho
                {
                    AreaDescansoId = area3.AreaDescansoId,
                    TrilhoId = trilho3.TrilhoId
                }

            );
        }

        private static void EnsureEstadosTrilhosPopulated(TurismoDbContext dbContext)
        {
            Estado estado1 = dbContext.Estados.SingleOrDefault(e => e.Nome == "Aberto");

            Trilho trilho1 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Primeiro Trilho");
            Trilho trilho2 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Trilho Grande");
            Trilho trilho3 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Santo Caminho");

            dbContext.EstadosTrilho.AddRange(
                new EstadoTrilho
                {
                    EstadoId = estado1.EstadoId,
                    TrilhoId = trilho1.TrilhoId,
                    DataInicio = new DateTime(2017, 11, 25),
                    Causa = "Alteração de sazonalidade"
                },
                new EstadoTrilho
                {
                    EstadoId = estado1.EstadoId,
                    TrilhoId = trilho2.TrilhoId,
                    DataInicio = new DateTime(2017, 11, 26),
                    Causa = "Mau estado do trilho"
                },
                new EstadoTrilho
                {
                    EstadoId = estado1.EstadoId,
                    TrilhoId = trilho3.TrilhoId,
                    DataInicio = new DateTime(2017, 12, 01),
                    Causa = "Mau estado do trilho"
                }

            );
        }
        private static void EnsurePontosInteresseTrilhosPopulated(TurismoDbContext dbContext)
        {
            PontoInteresse pi1 = dbContext.PontosInteresse.SingleOrDefault(p => p.Nome == "Igreja Secular");
            PontoInteresse pi2 = dbContext.PontosInteresse.SingleOrDefault(p => p.Nome == "Estátua de Napoleão");
            PontoInteresse pi3 = dbContext.PontosInteresse.SingleOrDefault(p => p.Nome == "Mosteiro da Serra");

            Trilho trilho1 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Primeiro Trilho");
            Trilho trilho2 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Trilho Grande");
            Trilho trilho3 = dbContext.Trilhos.SingleOrDefault(t => t.Nome == "Santo Caminho");

            dbContext.PontosInteresseTrilho.AddRange(
                new PontoInteresseTrilho
                {
                    PontoInteresseId = pi1.PontoInteresseId,
                    TrilhoId = trilho1.TrilhoId
                },
                new PontoInteresseTrilho
                {
                    PontoInteresseId = pi2.PontoInteresseId,
                    TrilhoId = trilho2.TrilhoId
                },
                new PontoInteresseTrilho
                {
                    PontoInteresseId = pi3.PontoInteresseId,
                    TrilhoId = trilho3.TrilhoId
                }

            );
        }
    }
}
