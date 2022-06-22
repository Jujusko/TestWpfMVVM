using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewWpfTutor6.Commands;
using NewWpfTutor6.DBLay;
using NewWpfTutor6.DBModel;
using NewWpfTutor6.Helpers;
using NewWpfTutor6.UIModels;

namespace NewWpfTutor6.ViewModel.PopupWindowViews
{
    public class AddTranzactionViewModel : BaseViewModel, ICloseWindow
    {
        private AppDBContext dBContext = new();

        private TranzactionUI _tranzaction;
        public TranzactionUI Tranzaction
        {
            get => _tranzaction;
            set => SetProperty(ref _tranzaction, value);
        }

        public AddTranzactionViewModel(UserUI user)
        {
            _tranzaction = new(0, "");
            _tranzaction.UserId = user.Id;
        }

        private RelayCommand _addTranzactionCommand;
        public RelayCommand AddTranzactionCommand
        {
            get
            {
                return _addTranzactionCommand ??
                  (_addTranzactionCommand = new RelayCommand(obj =>
                  {
                      var toDb = CustomMapper.GetInstance().Map<Tranzaction>(_tranzaction);
                      var dbUser = dBContext.Users.Single(x => x.Id == _tranzaction.UserId);
                      dBContext.Tranzactions.Add(toDb);
                      dbUser.Balance -= toDb.Cost;
                      dBContext.SaveChanges();
                      Close?.Invoke();
                  }));

            }
        }
        public Action Close { get; set; }
        bool ICloseWindow.CanClose()
        {
            if (_tranzaction.Name != null)
                return true;
            return false;
        }
    }
}
