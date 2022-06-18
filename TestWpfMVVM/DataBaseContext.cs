using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWpfMVVM.Model;

namespace TestWpfMVVM
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DefaultConnection")
        {

        }
        public DbSet<CommonUser> Users {get; set;}
    }
}
