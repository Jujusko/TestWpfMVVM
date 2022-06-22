using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewWpfTutor6.View.PopUpWindows;
using NewWpfTutor6.ViewModel.PopupWindowViews;

namespace NewWpfTutor6.Helpers.WindowServices
{
    public class AddTranzactionWindowService : IAnotherWindowService
    {
        public void ShowWindowService(object vm)
        {
            var dialog = new AddTranzaction((AddTranzactionViewModel)vm);
            dialog.ShowDialog();
        }

        public void ShowWindowService(string name)
        {
            throw new NotImplementedException();
        }
    }
}
