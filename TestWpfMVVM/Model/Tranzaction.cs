using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWpfMVVM.Helpers;

namespace TestWpfMVVM.Model
{
    public class Tranzaction : MyNotifyPropChanged
    {
        private string _tranzName;
        public string TranzName
        { get => _tranzName; set => SetProperty(ref _tranzName, value); }

        private int _cost;
        public int Cost
        { get => _cost; set => SetProperty(ref _cost, value); }


    }
}
