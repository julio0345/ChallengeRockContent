using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Model
{
    public class ApplicationDbContext : DbContext
    {
        private IConfiguration _config;
        public ApplicationDbContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Article> Article { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["DefaultConnection"]);
        }
    }
}
