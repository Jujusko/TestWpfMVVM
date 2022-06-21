﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewWpfTutor6.ViewModel;

namespace NewWpfTutor6.Helpers
{
    public class AnotherWindowService : IAnotherWindowService
    {
       public void ShowWindowService(object vm)
        {
            var dialog = new MainWindow((MainViewModel) vm);
            dialog.Show();
        }
    }
}
