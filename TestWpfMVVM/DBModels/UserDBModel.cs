using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfMVVM.DBModels
{
    public class UserDBModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balamce { get; set; }

        public virtual ICollection<TranzactionsDBModel>
            Tranzactions
        { get; private set; } =
            new ObservableCollection<TranzactionsDBModel>();
    }
}
