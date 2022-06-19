using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1
{
    public class AppContext : DbContext
    {
        public DbSet<Users> Users{ get; set; }
        public DbSet<Interests> Interests { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=test.db");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
