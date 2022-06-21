using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NewWpfTutor6.Commands;
using NewWpfTutor6.DBLay;
using NewWpfTutor6.DBModel;
using NewWpfTutor6.Helpers;
using NewWpfTutor6.UIModels;

namespace NewWpfTutor6.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private AppDBContext dBContext = new();

        private UserUI _user;
        private User dbHelper;
        private ObservableCollection<TranzactionUI> _tranzactions;
        public ObservableCollection<TranzactionUI> Tranzactions
        {
            get => _tranzactions;
            set => SetProperty(ref _tranzactions, value);
        }
        public UserUI User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        private TranzactionUI _newTranz;
        public TranzactionUI NewTranz
        {
            get => _newTranz;
            set => SetProperty(ref _newTranz, value);
        }

        private TranzactionUI _selectedTranz;
        public TranzactionUI SelectedTranz
        {
            get => _selectedTranz;
            set => SetProperty(ref _selectedTranz, value);
        }


        public MainViewModel(UserUI user)
        {
            _user = user;
            _newTranz = new();
            _tranzactions = new();
            _selectedTranz = new();
            User userId = dBContext.Users.FirstOrDefault(x => x.Name == _user.Name);
            _user.Balance = userId.Balance;
            dbHelper = userId;
            var dbTranzes = dBContext.Tranzactions.Where(x => x.UserId == userId.Id).ToArray();
            foreach (var tr in dbTranzes)
            {
                var uiTranz = CustomMapper.GetInstance().Map<TranzactionUI>(tr);
                _tranzactions.Add(uiTranz);
            }
        }

        private RelayCommand _addTranzactionCommand;

        public RelayCommand AddTranzactionCommand
        {
            get
            {
                return _addTranzactionCommand ??
                  (_addTranzactionCommand = new RelayCommand(obj =>
                  {
                      var toDb = CustomMapper.GetInstance().Map<Tranzaction>(_newTranz);
                      toDb.User = dbHelper;

                      Tranzactions.Add(new TranzactionUI(NewTranz.Cost, NewTranz.Name));
                      dBContext.Tranzactions.Add(toDb);
                      dbHelper.Balance -= toDb.Cost;
                      dBContext.SaveChanges();
                      _user.Balance -= toDb.Cost;
                  }));
            }
        }

        private RelayCommand _removeTranzactionCommand;

        public RelayCommand RemoveTranzactionCommand
        {
            get
            {
                var a = 1;
                return _removeTranzactionCommand ??
                  (_removeTranzactionCommand = new RelayCommand(obj =>
                  {
                      Tranzactions.Remove(_selectedTranz);

                      var a = dBContext.Tranzactions.Single(x => x.Id == _selectedTranz.Id);
                      dBContext.Tranzactions.Remove(a);
                      dBContext.SaveChanges();
                  }));
            }
        }
    }
}
