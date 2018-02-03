using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IPGTrails4Health.Models;

namespace IPGTrails4Health.Data
{
    public class LoginsDbContext : IdentityDbContext<ApplicationUser>
    {
        public LoginsDbContext(DbContextOptions<LoginsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}