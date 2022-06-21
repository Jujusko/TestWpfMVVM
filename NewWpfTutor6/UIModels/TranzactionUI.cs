﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewWpfTutor6.ViewModel;

namespace NewWpfTutor6.UIModels
{
    public class TranzactionUI : MyNotifyPropChanged
    {
        private int _id;
        public int Id
        { 
            get => _id;
            set => SetProperty(ref _id, value); 
        }

        private double _cost;
        public double Cost
        {
            get => _cost;
            set => SetProperty(ref _cost, value);
        }
        private int _userId;
        public int UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private string _name;

        public string Name 
        { 
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public TranzactionUI()
        {

        }
        public TranzactionUI(double cost, string name)
        {
            Cost = cost;
            Name = name;
        }
    }
}
