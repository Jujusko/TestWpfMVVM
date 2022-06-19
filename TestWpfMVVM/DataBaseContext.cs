using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWpfMVVM.DBModels;
using TestWpfMVVM.Model;

namespace TestWpfMVVM
{
    public class DataBaseContext : DbContext
    {
        public DbSet<UserDBModel> Users {get; set;}
        public DbSet<TranzactionsDBModel> Tranzactions {get; set;}

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=FinanceTracking.db");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
