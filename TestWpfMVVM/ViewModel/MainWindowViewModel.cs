using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestWpfMVVM.Helpers;
using TestWpfMVVM.Model;

namespace TestWpfMVVM.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private CommonUser _currentUser;


        private string _test;

        public string Test
        {
            get => _test;
            set => SetProperty(ref _test, value);
        }

        public CommonUser currentUser
        {
            get => _currentUser;
            set => SetProperty(ref _currentUser, value);
        }

        private Tranzaction _selectedTranzaction;
        public Tranzaction selectedTranzaction
        { 
            get => _selectedTranzaction;
            set => SetProperty(ref _selectedTranzaction, value);
        }


        public MainWindowViewModel()
        {
            _currentUser = new();
            _currentUser.Balance = 100;
            _currentUser.Name = "Empty";
        }




        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Tranzaction tranz = new Tranzaction();
                      _currentUser.Tranzactions.Insert(0, tranz);
                      _selectedTranzaction = tranz;
                  }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Tranzaction tranz = obj as Tranzaction;
                      if (tranz != null)
                      {
                          currentUser.Tranzactions.Remove(tranz);
                      }
                  },
                 (obj) => currentUser.Tranzactions.Count > 0));
            }
        }
    }
}
