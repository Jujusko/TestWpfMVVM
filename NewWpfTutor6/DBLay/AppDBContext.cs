using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewWpfTutor6.DBModel;

namespace NewWpfTutor6.DBLay
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DataFile.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tranzaction> Tranzactions { get; set; }
    }
}
