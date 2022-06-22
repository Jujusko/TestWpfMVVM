using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using NewWpfTutor6.Commands;
using NewWpfTutor6.DBLay;
using NewWpfTutor6.DBModel;
using NewWpfTutor6.Helpers;
using NewWpfTutor6.Helpers.WindowServices;
using NewWpfTutor6.UIModels;

namespace NewWpfTutor6.ViewModel
{
    public class RegisterFormViewModel : BaseViewModel, ICloseWindow
    {

        private AppDBContext dBContext = new();
        IAnotherWindowService windowHelp = new MainWindowService();

        public bool CanClose = false;



        private UserUI _user;
        public UserUI User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public RegisterFormViewModel()
        {
            _user = new();
            CanClose = true;
        }

        private RelayCommand _acceptCommand;

        public RelayCommand AcceptCommand
        {
            get
            {
                return _acceptCommand ??
                  (_acceptCommand = new RelayCommand(obj =>
                  {
                      var toDb = CustomMapper.GetInstance().Map<User>(_user);
                      var result = dBContext.Users.FirstOrDefault(a => a.Name == _user.Name);
                      if (result == null)
                      {
                        dBContext.Users.Add(toDb);
                        dBContext.SaveChanges();
                      }
                      ExecuteShowWindow();
                      Close?.Invoke();
                  }));
            }
        }

        private void ExecuteShowWindow()
        {
            MainViewModel vm = new(_user);
            windowHelp.ShowWindowService(vm);
        }

        public Action Close { get; set; }

        bool ICloseWindow.CanClose()
        {
            if (User.Name != null)
                return true;
            return false;
        }
    }
}
