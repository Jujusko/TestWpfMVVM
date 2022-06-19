using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestWpfMVVM.Helpers;

namespace TestWpfMVVM.Model
{
    public class CommonUser : MyNotifyPropChanged
    {
        private string _name;
        private double _balance;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public double Balance
        {
            get => _balance;
            set => SetProperty(ref _balance, value);
        }

        private ObservableCollection<Tranzaction> _tranzactions;
        public ObservableCollection<Tranzaction> Tranzactions
        {
            get => _tranzactions;
            set => SetProperty(ref _tranzactions, value);
        }
        public CommonUser() => _tranzactions = new();

    }
}
