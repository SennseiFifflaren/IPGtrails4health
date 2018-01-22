using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IPGTrails4Health.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TurismoDbContext>
    {
        public TurismoDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TurismoDbContext>();

            var connectionString = configuration.GetConnectionString("ConnectionStringIPGTrails4Health");

            builder.UseSqlServer(connectionString);

            return new TurismoDbContext(builder.Options);
        }
    }
}