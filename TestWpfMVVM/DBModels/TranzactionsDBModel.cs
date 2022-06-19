using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfMVVM.DBModels
{
    public class TranzactionsDBModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }

        public int UserId { get; set; }
        public virtual UserDBModel User { get; set; }

    }
}
