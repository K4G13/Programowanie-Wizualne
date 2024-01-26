using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DAOSql
{
    internal class DatabaseContext : DbContext
    {
        private readonly IConfiguration conf;
        public DatabaseContext() { }
        public DatabaseContext(IConfiguration _conf)
        {
            conf = _conf;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(conf.GetConnectionString("sqlite"));
            optionsBuilder.UseSqlite("Data source=DATABASE.db");
        }
        
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
